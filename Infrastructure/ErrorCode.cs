using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrientadorVocacionalAPI
{
    public enum ErrorCode
    {
        ErrorInterno = 500,
        // Datos no encontrados
        ClienteNoEncontrado = 1001,
        RegistroNoEncontrado = 1002,
        BaseNoEncontrada = 1003,
        InformacionIncorrecta = 1111,

        PeticionErronea = 2000,
        ErrorInsertarRegistro = 2001,
        ClienteRegistradoIncorrectamente = 2002,
        RegistroExistente = 2003,
        RegistroEnUso = 2004,
        ErrorActualizarRegistro = 2005,
        ErrorEliminarRegistro = 2006,

        // Privilegios
        SinPrivilegios = 3000,



    }
}
