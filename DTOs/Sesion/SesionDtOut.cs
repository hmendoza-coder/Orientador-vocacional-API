using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace OrientadorVocacionalAPI.DTOs
{
    public class SesionDtOut
    {
        public string IdSesion { get; set; }

        public Models.Credencial.Estatus Estatus { get; set; }
    }
}
