namespace adminEmpresa;

public enum Cargos{
    Auxiliar, 
    Administrativo,
    Ingeniero,
    Especialista, 
    Investigador
}


public class Empleado{
    private string nombre;
    private string apellido;
    private DateTime fechaNac;
    private char estadoCivil;
    private char genero;
    private DateTime fechaIngreso;
    private double sueldoBasico;
    private Cargos cargo;

    public string Nombre { set => nombre = value; }
    public string Apellido { set => apellido = value; }
    public DateTime FechaNac { set => fechaNac = value; }
    public char EstadoCivil { set => estadoCivil = value; }
    public char Genero { set => genero = value; }
    public DateTime FechaIngreso { set => fechaIngreso = value; }
    public double SueldoBasico { set => sueldoBasico = value; }
    public Cargos Cargo { set => cargo = value; }

    public int Antiguedad(){
        return ((DateTime.Now.Subtract(fechaIngreso).Days) / 365);
    }

    public int Edad(){
        return ((DateTime.Now.Subtract(fechaNac).Days) / 365);
    }

    public int AniosJubilacion(){
        if(genero == 'M'){
            return (65 - Edad());
        } else{
            return (60 - Edad());
        }
    }

    private double adicional(){
        double adi = 0d;

        if(Antiguedad() < 20) adi = sueldoBasico*(Antiguedad() / 100d);
        if(cargo == Cargos.Ingeniero || cargo == Cargos.Especialista) adi *= 1.5d;
        if(estadoCivil == 'C') adi += 15000d;

        return adi;
    }

    public double Salario(){
        return (sueldoBasico + adicional());
    }

    public void MostrarDatos(){
        Console.WriteLine($"Apellido: {apellido}");
        Console.WriteLine($"Nombre: {nombre}");
        Console.WriteLine($"Fecha de Nacimiento: {fechaNac.ToShortDateString()}");
        Console.WriteLine($"Edad: {Edad()}");
        Console.WriteLine($"Estado civil: {estadoCivil}");
        Console.WriteLine($"Genero: {genero}");
        Console.WriteLine($"Fecha de ingreso a la empresa: {fechaIngreso.ToShortDateString()}");
        Console.WriteLine($"Sueldo básico: {sueldoBasico.ToString("NO")}");
        Console.WriteLine($"Cargo: {cargo}");
        Console.WriteLine($"Antigüedad: {Antiguedad()}");
        Console.WriteLine($"Cantidad de años faltante para jubilarse: {AniosJubilacion()}");
        Console.WriteLine($"Salario: {Salario().ToString("N0")}");
    }
    
}