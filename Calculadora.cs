namespace spaceCalc;

public class Calculadora{
    private double resultado;

    public double Resultado { get => resultado;}

    public void Sumar(double termino){
        resultado += termino;
    }

    public void Restar(double termino){
        resultado -= termino;
    }

    public void Multiplicar(double termino){
        resultado *= termino;
    }

    public void Dividir(double termino){
        resultado /= termino;
    }

    public void Limpiar(){
        resultado = 0;
    }
}