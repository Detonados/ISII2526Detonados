﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DataType = System.ComponentModel.DataAnnotations.DataType;

namespace AppForSEII2526.API.Models
{
    public class Rental
    {
        // Clave primaria
        [Key]
        public int Id { get; set; }

        // Jojos
        //---------------------------------------------------------------------------------------

        [Required(ErrorMessage = "La dirección de entrega es obligatoria.")]
        [StringLength(200, ErrorMessage = "La dirección no puede superar los 200 caracteres.")]
        public string DeliveryAddress { get; set; }
        //---------------------------------------------------------------------------------------

        // Clases y Relaciones a otras tablas

        [Required(ErrorMessage = "El método de pago es obligatorio.")]
        public PaymentMethod PaymentMethod { get; set; }

        public RentDevice RentDevice { get; set; }
        //---------------------------------------------------------------------------------------
        // Fechas DateTypes
        public ApplicationUser ApplicationUser { get; set; }
        [DataType(DataType.Date), Display(Name = "Fecha de alquiler")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime RentalDate { get; set; } = DateTime.UtcNow;
        [DataType(DataType.Date), Display(Name = "Fecha inicio alquiler")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime RentalDateFrom { get; set; }
        [DataType(DataType.Date), Display(Name = "Fecha fin alquiler")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]        
        public DateTime RentalDateTo { get; set; }
        //---------------------------------------------------------------------------------------
        //Precios

        [Required(ErrorMessage = "El precio total es obligatorio.")]
        [DataType(DataType.Currency)]
        [Range(0, double.MaxValue, ErrorMessage = "El precio total debe ser positivo.")]
        public double TotalPrice { get; set; }

        //---------------------------------------------------------------------------------------

        // Constructores
        public Rental()
        {
            // Constructor vacío 
        }
        //Constructor lleno
        public Rental(
            int id,
            string name,
            string surname,
            string deliveryAddress,
            PaymentMethod paymentMethod,
            RentDevice rentDevice,
            DateTime rentalDate,
            DateTime rentalDateFrom,
            DateTime rentalDateTo,
            double totalPrice)
        {
            Id = id;
            DeliveryAddress = deliveryAddress;
            PaymentMethod = paymentMethod;
            RentDevice = rentDevice;
            RentalDate = rentalDate;
            RentalDateFrom = rentalDateFrom;
            RentalDateTo = rentalDateTo;
            TotalPrice = totalPrice;
        }

        //---------------------------------------------------------------------------------------

        //Metodos de clase  equals y gethashcode
        public override bool Equals(object obj) => obj is Rental r && this.Id == r.Id;
        public override int GetHashCode() => Id.GetHashCode();

    }
}