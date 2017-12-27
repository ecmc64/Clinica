using Clinica.Web.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinica.Web.Data
{
    public class ClinicaSeed
    {
        public static void Initialize(IServiceProvider provider)
        {
            var context = provider.GetRequiredService<ApplicationDbContext>();

            ObtieneCentroMedico().ForEach(s => context.CentroMedico.Add(s));
            context.SaveChanges();
            ObtieneCitaEstado().ForEach(s => context.CitaEstado.Add(s));
            context.SaveChanges();
            ObtieneCitaTipo().ForEach(s => context.CitaTipo.Add(s));
            context.SaveChanges();
            ObtienePacienteCategoria().ForEach(s => context.PacienteCategoria.Add(s));
            context.SaveChanges();
            ObtieneProfesionalTipo().ForEach(s => context.ProfesionalTipo.Add(s));
            context.SaveChanges();
            ObtieneProfesional().ForEach(s => context.Profesional.Add(s));
            context.SaveChanges();
            ObtienePaciente().ForEach(s => context.Paciente.Add(s));
            context.SaveChanges();
            ObtieneTarifa().ForEach(s => context.Tarifa.Add(s));
            context.SaveChanges();
        }

        private static List<CentroMedico> ObtieneCentroMedico()
        {
            var lista = new List<CentroMedico>
            {
            new CentroMedico{Nombre="San Isidro",Direccion="Av Javier Prado Este 444",Telefonos = "432-1234, 987654321"},
            new CentroMedico{Nombre="San Miguel",Direccion="Av Patriotas 555",Telefonos = "963852741"}
            };
            return lista;
        }
        private static List<CitaEstado> ObtieneCitaEstado()
        {
            var lista = new List<CitaEstado>
            {
            new CitaEstado{Descripcion="Programado", Estado=true },
            new CitaEstado{Descripcion="Cancelado", Estado=true },
            new CitaEstado{Descripcion="Realizado", Estado=true }
            };
            return lista;
        }
        private static List<CitaTipo> ObtieneCitaTipo()
        {
            var lista = new List<CitaTipo>
            {
            new CitaTipo{Descripcion="Consulta", Estado=true },
            new CitaTipo{Descripcion="Terapia física", Estado=true },
            new CitaTipo{Descripcion="Cirugía", Estado=true },
            new CitaTipo{Descripcion="Psicología", Estado=true }
            };
            return lista;
        }
        private static List<PacienteCategoria> ObtienePacienteCategoria()
        {
            var lista = new List<PacienteCategoria>
            {
            new PacienteCategoria{Descripcion="Normal", Estado=true },
            new PacienteCategoria{Descripcion="EPS Pacífico", Estado=true },
            new PacienteCategoria{Descripcion="ESSALUD", Estado=true },
            new PacienteCategoria{Descripcion="Rimac", Estado=true }
            };
            return lista;
        }
        private static List<ProfesionalTipo> ObtieneProfesionalTipo()
        {
            var lista = new List<ProfesionalTipo>
            {
            new ProfesionalTipo{Descripcion="Médico", Estado=true },
            new ProfesionalTipo{Descripcion="Enfermera", Estado=true },
            new ProfesionalTipo{Descripcion="Psicologa", Estado=true },
            new ProfesionalTipo{Descripcion="Terapeuta físico", Estado=true }
            };
            return lista;
        }
        private static List<Profesional> ObtieneProfesional()
        {
            var lista = new List<Profesional>
            {
            new Profesional{Nombres="Julio Sanchez", ProfesionalTipoId = 1, Estado=true },
            new Profesional{Nombres="Karla Castillo", ProfesionalTipoId = 1, Estado=true },
            new Profesional{Nombres="Katty Diaz", ProfesionalTipoId = 2, Estado=true },
            new Profesional{Nombres="Paola Melendez", ProfesionalTipoId = 2, Estado=true },
            new Profesional{Nombres="Patricia Saenz", ProfesionalTipoId = 3, Estado=true },
            new Profesional{Nombres="Diana Sabina", ProfesionalTipoId = 3, Estado=true },
            new Profesional{Nombres="Jose Andrade", ProfesionalTipoId = 4, Estado=true },
            new Profesional{Nombres="Carlos Terrones", ProfesionalTipoId = 4, Estado=true },

            };
            return lista;
        }
        private static List<Paciente> ObtienePaciente()
        {
            var lista = new List<Paciente>
            {
            new Paciente{Nombres="Luis", ApellidoPaterno="Gonzales", ApellidoMaterno="Carrera", PacienteCategoriaId = 1, Estado=true },
            new Paciente{Nombres="Eduardo", ApellidoPaterno="Perez", ApellidoMaterno="Gutierrea",PacienteCategoriaId = 1, Estado=true },
            new Paciente{Nombres="Madeleine", ApellidoPaterno="Sanchez", ApellidoMaterno="Rios",PacienteCategoriaId = 2, Estado=true },
            new Paciente{Nombres="Eduardo", ApellidoPaterno="Roca", ApellidoMaterno="Postillo",PacienteCategoriaId = 2, Estado=true },
            new Paciente{Nombres="Ana María", ApellidoPaterno="Velasquez", ApellidoMaterno="Hermes",PacienteCategoriaId = 3, Estado=true },
            new Paciente{Nombres="Valeria", ApellidoPaterno="Murcia", ApellidoMaterno="Balvin",PacienteCategoriaId = 3, Estado=true },
            new Paciente{Nombres="Sara", ApellidoPaterno="Salazar", ApellidoMaterno="Galarza",PacienteCategoriaId = 4, Estado=true },
            new Paciente{Nombres="Alberto", ApellidoPaterno="Litama", ApellidoMaterno="Rodriguez",PacienteCategoriaId = 4, Estado=true }
            };
            return lista;
        }
        private static List<Tarifa> ObtieneTarifa()
        {
            var lista = new List<Tarifa>
            {
            new Tarifa { Estado = true, CentroMedicoId = 1, CitaTipoId = 1, PacienteCategoriaId = 1, Precio = 63 },
            new Tarifa { Estado = true, CentroMedicoId = 1, CitaTipoId = 1, PacienteCategoriaId = 2, Precio = 80 },
            new Tarifa { Estado = true, CentroMedicoId = 1, CitaTipoId = 1, PacienteCategoriaId = 3, Precio = 58 },
            new Tarifa { Estado = true, CentroMedicoId = 1, CitaTipoId = 1, PacienteCategoriaId = 4, Precio = 78 },
            new Tarifa { Estado = true, CentroMedicoId = 1, CitaTipoId = 2, PacienteCategoriaId = 1, Precio = 65 },
            new Tarifa { Estado = true, CentroMedicoId = 1, CitaTipoId = 2, PacienteCategoriaId = 2, Precio = 76 },
            new Tarifa { Estado = true, CentroMedicoId = 1, CitaTipoId = 2, PacienteCategoriaId = 3, Precio = 71 },
            new Tarifa { Estado = true, CentroMedicoId = 1, CitaTipoId = 2, PacienteCategoriaId = 4, Precio = 57 },
            new Tarifa { Estado = true, CentroMedicoId = 1, CitaTipoId = 3, PacienteCategoriaId = 1, Precio = 69 },
            new Tarifa { Estado = true, CentroMedicoId = 1, CitaTipoId = 3, PacienteCategoriaId = 2, Precio = 50 },
            new Tarifa { Estado = true, CentroMedicoId = 1, CitaTipoId = 3, PacienteCategoriaId = 3, Precio = 98 },
            new Tarifa { Estado = true, CentroMedicoId = 1, CitaTipoId = 3, PacienteCategoriaId = 4, Precio = 55 },
            new Tarifa { Estado = true, CentroMedicoId = 1, CitaTipoId = 4, PacienteCategoriaId = 1, Precio = 85 },
            new Tarifa { Estado = true, CentroMedicoId = 1, CitaTipoId = 4, PacienteCategoriaId = 2, Precio = 91 },
            new Tarifa { Estado = true, CentroMedicoId = 1, CitaTipoId = 4, PacienteCategoriaId = 3, Precio = 55 },
            new Tarifa { Estado = true, CentroMedicoId = 1, CitaTipoId = 4, PacienteCategoriaId = 4, Precio = 65 },
            new Tarifa { Estado = true, CentroMedicoId = 2, CitaTipoId = 1, PacienteCategoriaId = 1, Precio = 57 },
            new Tarifa { Estado = true, CentroMedicoId = 2, CitaTipoId = 1, PacienteCategoriaId = 2, Precio = 65 },
            new Tarifa { Estado = true, CentroMedicoId = 2, CitaTipoId = 1, PacienteCategoriaId = 3, Precio = 67 },
            new Tarifa { Estado = true, CentroMedicoId = 2, CitaTipoId = 1, PacienteCategoriaId = 4, Precio = 69 },
            new Tarifa { Estado = true, CentroMedicoId = 2, CitaTipoId = 2, PacienteCategoriaId = 1, Precio = 75 },
            new Tarifa { Estado = true, CentroMedicoId = 2, CitaTipoId = 2, PacienteCategoriaId = 2, Precio = 53 },
            new Tarifa { Estado = true, CentroMedicoId = 2, CitaTipoId = 2, PacienteCategoriaId = 3, Precio = 66 },
            new Tarifa { Estado = true, CentroMedicoId = 2, CitaTipoId = 2, PacienteCategoriaId = 4, Precio = 83 },
            new Tarifa { Estado = true, CentroMedicoId = 2, CitaTipoId = 3, PacienteCategoriaId = 1, Precio = 81 },
            new Tarifa { Estado = true, CentroMedicoId = 2, CitaTipoId = 3, PacienteCategoriaId = 2, Precio = 76 },
            new Tarifa { Estado = true, CentroMedicoId = 2, CitaTipoId = 3, PacienteCategoriaId = 3, Precio = 73 },
            new Tarifa { Estado = true, CentroMedicoId = 2, CitaTipoId = 3, PacienteCategoriaId = 4, Precio = 60 },
            new Tarifa { Estado = true, CentroMedicoId = 2, CitaTipoId = 4, PacienteCategoriaId = 1, Precio = 84 },
            new Tarifa { Estado = true, CentroMedicoId = 2, CitaTipoId = 4, PacienteCategoriaId = 2, Precio = 62 },
            new Tarifa { Estado = true, CentroMedicoId = 2, CitaTipoId = 4, PacienteCategoriaId = 3, Precio = 50 },
            new Tarifa { Estado = true, CentroMedicoId = 2, CitaTipoId = 4, PacienteCategoriaId = 4, Precio = 95 }
            };
            return lista;
        }
    }
}
