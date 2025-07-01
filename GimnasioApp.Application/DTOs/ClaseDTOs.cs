using System;
using System.ComponentModel.DataAnnotations;

namespace GimnasioApp.Application.DTOs
{
    public class ClaseDTO
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; } = string.Empty;

        [Display(Name = "Capacidad Máxima")]
        [Range(1, int.MaxValue, ErrorMessage = "La capacidad máxima debe ser al menos 1.")]
        public int CapacidadMaxima { get; set; }

        [Display(Name = "Hora de Inicio")]
        [DataType(DataType.Time)] 
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan HoraInicio { get; set; }

        [Display(Name = "Hora de Fin")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan HoraFin { get; set; }

        [Display(Name = "Horario")]

        public string Horario => $"{HoraInicio.ToString(@"hh\:mm")} - {HoraFin.ToString(@"hh\:mm")}";
    }

    public class ClaseCreateDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(500)]
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "La capacidad máxima es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La capacidad máxima debe ser al menos 1.")]
        public int CapacidadMaxima { get; set; }

        [Required(ErrorMessage = "La hora de inicio es obligatoria.")]
        [DataType(DataType.Time)]
        public TimeSpan HoraInicio { get; set; }

        [Required(ErrorMessage = "La hora de fin es obligatoria.")]
        [DataType(DataType.Time)]
        public TimeSpan HoraFin { get; set; }
    }

    public class ClaseUpdateDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [StringLength(500)]
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "La capacidad máxima es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La capacidad máxima debe ser al menos 1.")]
        public int CapacidadMaxima { get; set; }

        [Required(ErrorMessage = "La hora de inicio es obligatoria.")]
        [DataType(DataType.Time)]
        public TimeSpan HoraInicio { get; set; }

        [Required(ErrorMessage = "La hora de fin es obligatoria.")]
        [DataType(DataType.Time)]
        public TimeSpan HoraFin { get; set; }
    }
}