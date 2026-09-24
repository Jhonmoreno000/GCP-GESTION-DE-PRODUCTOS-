namespace WinFormsApp1
{
    /// <summary>
    /// Punto de entrada principal para la aplicación de escritorio GCP (Gestión y Control de Productos).
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Método principal (Main) que inicializa y ejecuta la aplicación de Windows Forms.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Inicializa la configuración visual de la aplicación (fuentes, temas visuales y estilos modernos)
            ApplicationConfiguration.Initialize();

            // Ejecuta el formulario principal 'GPC' (Gestión de Productos y Clientes)
            Application.Run(new GPC());
        }
    }
}
