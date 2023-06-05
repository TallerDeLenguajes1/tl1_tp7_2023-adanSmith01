using adminEmpresa;

internal class Program
{
    private static void Main(string[] args)
    {
        // Funcion 
        void empleadoProximoJubilacion(Empleado[] empleados)
        {
            int prox = int.MaxValue;
            int j = 0;

            for (int i = 0; i < empleados.Count(); i++)
            {
                if (empleados[i].AniosJubilacion() <= prox)
                {
                    prox = empleados[i].AniosJubilacion();
                    j = i;
                }
            }

            empleados[j].MostrarDatos();
        }

        Empleado[] empleados = new Empleado[3];

        double montoTotal = 0d;

        // Datos del empleado 1
        empleados[0] = new Empleado();
        empleados[0].Apellido = "Perez";
        empleados[0].Nombre = "Rosa";
        empleados[0].FechaNac = new DateTime(1970, 2, 1);
        empleados[0].EstadoCivil = 'S';
        empleados[0].Genero = 'F';
        empleados[0].FechaIngreso = new DateTime(2001, 5, 8);
        empleados[0].SueldoBasico = 23000d;
        empleados[0].Cargo = Cargos.Especialista;

        // Datos del empleado 2
        empleados[1] = new Empleado();
        empleados[1].Apellido = "Gomez";
        empleados[1].Nombre = "Rafael";
        empleados[1].FechaNac = new DateTime(1967, 2, 1);
        empleados[1].EstadoCivil = 'C';
        empleados[1].Genero = 'M';
        empleados[1].FechaIngreso = new DateTime(2008, 4, 9);
        empleados[1].SueldoBasico = 65000d;
        empleados[1].Cargo = Cargos.Especialista;

        // Datos del empleado 3
        empleados[2] = new Empleado();
        empleados[2].Apellido = "Menendez";
        empleados[2].Nombre = "Gabriela";
        empleados[2].FechaNac = new DateTime(1968, 2, 1);
        empleados[2].EstadoCivil = 'S';
        empleados[2].Genero = 'F';
        empleados[2].FechaIngreso = new DateTime(2002, 10, 10);
        empleados[2].SueldoBasico = 14000d;
        empleados[2].Cargo = Cargos.Auxiliar;

        foreach (Empleado emp in empleados)
        {
            montoTotal += emp.Salario();
        }

        Console.WriteLine($"MONTO TOTAL A PAGAR EN CONCEPTO DE SALARIOS: {montoTotal.ToString("N0")}\n");
        Console.WriteLine("\n################ EMPLEADO PRÓXIMO A JUBILARSE ################\n");
        empleadoProximoJubilacion(empleados);
    }
}