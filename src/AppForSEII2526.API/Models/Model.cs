using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataType = System.ComponentModel.DataAnnotations.DataType;
namespace AppForSEII2526.API.Models
{
    public class Model
    {
        //---------------------------------------------------------------------------------------
        // Clave primaria
        [Key]
        public int Id { get; set; }
        //---------------------------------------------------------------------------------------
        // Campo requerido y longitud máxima
        [Required(ErrorMessage = "El nombre del modelo es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre del modelo no puede superar los 100 caracteres.")]
        public string NameModel { get; set; }
        //---------------------------------------------------------------------------------------
        // Relación uno-a-muchos: un Model tiene muchos Devices
        public IList<Device> Devices { get; set; } = new List<Device>();
        //---------------------------------------------------------------------------------------
        //contructor vacio
        public Model() { }
        //---------------------------------------------------------------------------------------
        //constructor con parametros
        public Model(int id, string nameModel)
        {
            Id = id;
            NameModel = nameModel;
        }
        //---------------------------------------------------------------------------------------
        //Metodos Equals y GetHashCode
        public override bool Equals(object obj)
        {
            return obj is Model m && this.Id == m.Id;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}