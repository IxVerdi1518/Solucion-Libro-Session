namespace LibroSession.Models
{
    public class Libro
    {
        private String autor;
        private String titulo;
        private String materia;
        private String estado;
        private String tipo;
        private String categoria;

        public Libro() { }

        public Libro(string autor, string titulo, string materia, string estado, string tipo, string categoria)
        {
            this.autor = autor;
            this.titulo = titulo;
            this.materia = materia;
            this.estado = estado;
            this.tipo = tipo;
            this.categoria = categoria;
        }

        public string Autor { get => autor; set => autor = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Materia { get => materia; set => materia = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string Categoria { get => categoria; set => categoria = value; }
    }
}
