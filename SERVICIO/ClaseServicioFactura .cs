using System.Text.RegularExpressions;

public class ServicioFactura
{
    // Método para validar los datos de la factura
    public bool ValidarFactura(Factura factura)
    {
        if (!Regex.IsMatch(factura.NroFactura, @"^\d{3}-\d{3}-\d{3}$"))
        {
            Console.WriteLine("El número de factura debe tener el formato XXX-XXX-XXX.");
            return false;
        }

        if (factura.Total <= 0 || factura.TotalIva5 <= 0 || factura.TotalIva10 <= 0)
        {
            Console.WriteLine("Los campos de total y de impuestos de la factura deben ser mayores que cero.");
            return false;
        }

        if (string.IsNullOrWhiteSpace(factura.TotalLetras) || factura.TotalLetras.Length < 6)
        {
            Console.WriteLine("El campo de total en letras es obligatorio y debe tener al menos 6 caracteres.");
            return false;
        }

        return true;
    }

    // Método para calcular el total de la factura incluyendo los impuestos
    public decimal CalcularTotalConImpuestos(decimal total, decimal iva5, decimal iva10)
    {
        return total + iva5 + iva10;
    }
}