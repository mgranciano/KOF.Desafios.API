# 🧠 ExpressionTreeMapper - Mapper genérico para entidades y DTOs

Este utilitario proporciona una forma eficiente y dinámica de mapear objetos entre entidades (`TSource`) y DTOs (`TDestination`) en un proyecto basado en Clean Architecture.

---

## 📦 ¿Qué hace?

- Mapea automáticamente propiedades por nombre y tipo entre dos clases.
- Genera funciones optimizadas en tiempo de ejecución mediante árboles de expresiones (`Expression Trees`).
- Elimina la necesidad de escribir manualmente los mapeos.
- Cumple con los principios SOLID (especialmente SRP y OCP).

---

## 🛠 Ejemplo de uso

Supón que tienes las siguientes clases:

```csharp
public class Desafio
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public DateTime FechaInicio { get; set; }
}

public class DesafioDto
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public DateTime FechaInicio { get; set; }
}