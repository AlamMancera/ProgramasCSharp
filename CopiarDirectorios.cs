class Program
    {
        static void Main(string[] args)
        {
            string origenDirectorio = @"F:\Documentos\Disco duro C Respaldo\source\repos\Seccion_11"; // Ruta de origen del directorio
            string destinoDirectorio = @"F:\Escritorio\Seccion_11"; // Ruta de destino del directorio

            // Llamamos al método "CopiarDirectorio" y le enviamos el origen y destino como argumentos
            CopiarDirectorio(origenDirectorio, destinoDirectorio);
        }
        static public void CopiarDirectorio(string origenDirectorioPa, string destinoDirectorioPa)
        {
            // Verificar si el directorio de destino no existe, crearlo si es necesario
            if (!Directory.Exists(destinoDirectorioPa))
            {
                Directory.CreateDirectory(destinoDirectorioPa);
            }                

            // Matriz para guardar los nombres de los archivos del directorio de origen
            string[] archivos = Directory.GetFiles(origenDirectorioPa);

            // Copiar archivos desde el directorio de origen al directorio de destino
            foreach (string archivo in archivos)
            {
                // Asignamos el nombre del archivo (matriz) y su extensión a la variable "nombre"
                string nombreArchivo = Path.GetFileName(archivo);
                // Concatenamos la ruta de destino con el nombre de cada archivo que obtuvimos de la matriz
                string rutaCompletaArchivo = Path.Combine(destinoDirectorioPa, nombreArchivo);
                // Copiamos cada archivo de la ruta original en la nueva ruta (se permite sobrescribir)
                File.Copy(archivo, rutaCompletaArchivo, true);
            }

            // Matriz para los nombres de los directorios
            string[] Subdirectorios = Directory.GetDirectories(origenDirectorioPa);

            // Recorrer y copiar subdirectorios de manera recursiva
            foreach (string subdirectorio in Subdirectorios)
            {
                // Obtenemos el nombre de cada directorio contenido en la matriz y se lo asignamos a la variable "nombreDirectorio"
                string nombreDirectorio = Path.GetFileName(subdirectorio);
                // Concatenamos la ruta de destino con el nombre de cada directorio que obtuvimos de la matriz
                string rutaCompletaDirectorio = Path.Combine(destinoDirectorioPa, nombreDirectorio);

                // Llamada recursiva para copiar el subdirectorio y sus contenidos.
                // Ahora el nombre completo del directorio será el parámetro "OrigenDirectorioPa"
                // Y "rutaCompletaDirectorio" será el parámetro "destinoDirectorioPa"
                CopiarDirectorio(subdirectorio, rutaCompletaDirectorio);
            }
        }
    }
