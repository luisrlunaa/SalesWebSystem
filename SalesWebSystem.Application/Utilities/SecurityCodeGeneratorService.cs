﻿using Microsoft.AspNetCore.Http;
using SalesWebSystem.Application.Services;
using SalesWebSystem.Application.Services.Abstracts;
using SalesWebSystem.Application.Utilities.Functions;

namespace SalesWebSystem.Application.Utilities
{
    public interface ISecurityCodeGeneratorService
    {
        Task<Result<string>> GenerateAndSend(string Correo);
    }

    public class SecurityCodeGeneratorService : ISecurityCodeGeneratorService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IEmailSender _emailSender;

        public SecurityCodeGeneratorService(IHttpContextAccessor httpContextAccessor, IEmailSender emailSender)
        {
            _httpContextAccessor = httpContextAccessor;
            _emailSender = emailSender;
        }

        public async Task<Result<string>> GenerateAndSend(string Correo)
        {
            try
            {
                var generator = new Random();
                var codigo = generator.Next(1, 999999).ToString("D6");
                _httpContextAccessor.HttpContext.Session.Set<string>(ConstantsSession.ValidationCode, codigo);

                if (string.IsNullOrWhiteSpace(Correo))
                    throw new Exception("Correo no encontrado");

                var message = new Message(new string[] { Correo }, $"Código de Validación del Sistema de Ventas e Inventario {codigo}", null, null);
                if (message != null)
                    await _emailSender.SendEmailAsync(message);

                return Result.Ok(codigo);
            }
            catch (Exception ex)
            {
                return Result.Fail<string>("Hubo un problema al procesar esta acción, Favor Ponerse en contacto con su suplidor " + ex.ToString());
            }
        }
    }
}
