using System.Text.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace OrientadorVocacionalAPI.DTOs
{
    public class SesionDtOut
    {
        public string IdSesion { get; set; }

        //[Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
        //[JsonConverter(typeof(StringEnumConverter))]
        public Models.Credencial.Estatus Estatus { get; set; }
    }
}
