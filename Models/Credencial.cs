﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrientadorVocacionalAPI.Models
{
    public class Credencial
    {
        public enum Estatus
        {
            UsuarioNoEncontrado = 0,
            PasswordErronea,
            Ok
        }
        public int IdPersona { get; set; }

        public string Password { get; set; }
    }
}
