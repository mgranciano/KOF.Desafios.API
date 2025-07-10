## 🧪 Ejecución de Pruebas Unitarias

### 🔹 Ejecutar todas las pruebas de la solución

Desde la raíz del proyecto:

```bash
dotnet test
```

Este comando compila la solución y ejecuta **todas las pruebas unitarias** de todos los proyectos `*.Tests` que se encuentren en la solución.

---

### 🔹 Ejecutar pruebas de un proyecto específico

Ejecutar pruebas de un proyecto individual, por ejemplo `KOF.Desafios.PublicAPI.Tests`:

```bash
dotnet test tests/KOF.Desafios.PublicAPI.Tests
```

---

### ⚙️ Opciones adicionales útiles

- **Ver salida detallada:**

  ```bash
  dotnet test --logger "console;verbosity=detailed"
  ```

- **Ejecutar sin reconstruir (más rápido si ya fue compilado):**

  ```bash
  dotnet test --no-build
  ```

- **Abortar al primer error:**

  ```bash
  dotnet test --blame
  ```

- **Especificar configuración y plataforma:**

  ```bash
  dotnet test -c Release --framework net9.0
  ```

---

### ✅ Requisitos

- [.NET 8 o .NET 9 SDK](https://dotnet.microsoft.com/download)
- xUnit instalado como framework de prueba (ya configurado en los proyectos `*.Tests`)
