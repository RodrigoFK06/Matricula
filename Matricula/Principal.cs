using CapaEntidad;
using CapaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matricula
{
    public partial class Principal : Form
    {
        private EstudiantesLogica estudianteLogica;

        private ProfesoresLogica profesorLogica;

        private MatriculasLogica matriculaLogica;

        private CursosLogica cursosLogica;

        private Estudiantes estuadianteSeleccionado;

        private Profesores profesorSeleccionado;

        private Cursos cursoSeleccionado;



        public Principal()
        {
            InitializeComponent();
            estudianteLogica = new EstudiantesLogica();
            profesorLogica = new ProfesoresLogica();
            matriculaLogica = new MatriculasLogica();
            cursosLogica = new CursosLogica();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            panelEstudiantes.Visible = false;
            panelProfesores.Visible = false;
            panelMatricula.Visible = false;
            panelCursos.Visible = false;
            CargarEstudiantes();
            CargarProfesores();
            CargarMatriculas();
            CargarCursos();
            CargarComboEstudiantes();
            CargarComboCursos();
            CargarComboProfesores();
        }

        private void CargarEstudiantes()
        {
            listadoEstudiantes.DataSource = estudianteLogica.ObtenerEstudiantes();
        }
        private void CargarProfesores()
        {
            listadoProfesores.DataSource = profesorLogica.ObtenerProfesores();
        }

        private void CargarCursos()
        {
            listadoCursos.DataSource = cursosLogica.ObtenerCursos();
        }

        private void CargarMatriculas()
        {
            // Obtener la lista de productos desde la lógica de negocios
            List<Matriculas> matriculas = matriculaLogica.ObtenerMatriculas();

            // Mostrar la lista en el DataGridView
            listadoMatriculas.DataSource = matriculas;
        }

        private void CargarComboEstudiantes()
        {
            // Obtener la lista de categorías desde la lógica de negocios
            List<Estudiantes> estudiantes = estudianteLogica.ObtenerEstudiantes();

            // Mostrar la lista en el ComboBox
            comboEstudiantes.DataSource = estudiantes;
            comboEstudiantes.DisplayMember = "nombres"; // Ajusta esto según la propiedad que represente el nombre de la categoría
            comboEstudiantes.ValueMember = "ID_estudiante"; // Ajusta esto según la propiedad que represente el ID de la categoría
        }

        private void CargarComboCursos()
        {
            // Obtener la lista de categorías desde la lógica de negocios
            List<Cursos> cursos = cursosLogica.ObtenerCursos();

            // Mostrar la lista en el ComboBox
            comboCursos.DataSource = cursos;
            comboCursos.DisplayMember = "nombre_curso"; // Ajusta esto según la propiedad que represente el nombre de la categoría
            comboCursos.ValueMember = "ID_curso"; // Ajusta esto según la propiedad que represente el ID de la categoría
        }

        private void CargarComboProfesores()
        {
            // Obtener la lista de profesores desde la lógica de negocios
            List<Profesores> profesores = profesorLogica.ObtenerProfesores();

            // Mostrar la lista en el ComboBox de profesores
            comboProfesor.DataSource = profesores;
            comboProfesor.DisplayMember = "nombres"; // Ajusta esto según la propiedad que represente el nombre del profesor
            comboProfesor.ValueMember = "ID_profesor"; // Ajusta esto según la propiedad que represente el ID del profesor
        }


        private void btnEstudiante_Click(object sender, EventArgs e)
        {
            panelEstudiantes.Visible = true;
            panelProfesores.Visible = false;
            panelMatricula.Visible = false;
            panelCursos.Enabled = false;
        }

        private void btnProfesores_Click(object sender, EventArgs e)
        {
            panelEstudiantes.Visible = false;
            panelMatricula.Visible = false;
            panelCursos.Enabled = false;
            panelProfesores.Visible = true;
            
        }

        private void btnNuevoEstudiante_Click(object sender, EventArgs e)
        {
            LimpiarCamposEstudiante();
        }
        private void LimpiarCamposEstudiante()
        {
            txtNombresEstudiantes.Text = string.Empty;
            txtApellidosEstudiante.Text = string.Empty;
            fechaNacPicker.Value = DateTime.Now; // Así se limpia el DateTimePicker
            txtCorreoEstudiantes.Text = string.Empty;
            txtDireccionEstudiantes.Text = string.Empty;
        }



        private void btnGuardarEstudiante_Click(object sender, EventArgs e)
        {
            // Validaciones de datos antes de guardar (puedes personalizar según tus necesidades)
            if (string.IsNullOrEmpty(txtNombresEstudiantes.Text) || string.IsNullOrEmpty(txtApellidosEstudiante.Text) || string.IsNullOrEmpty(txtCorreoEstudiantes.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Estudiantes nuevoEstudiante = new Estudiantes
            {
                nombres = txtNombresEstudiantes.Text,
                apellidos = txtApellidosEstudiante.Text,
                fecha_nacimiento = fechaNacPicker.Value,
                correo = txtCorreoEstudiantes.Text,
                direccion = txtDireccionEstudiantes.Text
            };

            // Llamar al método de la lógica para insertar el nuevo cliente
            estudianteLogica.InsertarEstudiante(nuevoEstudiante);

            // Actualizar la vista con los clientes actualizados
            CargarEstudiantes();
            CargarComboEstudiantes();

            // Limpiar los campos después de guardar
            LimpiarCamposEstudiante();
        }

        private void bntEditarEstudiante_Click(object sender, EventArgs e)
        {
            if (estuadianteSeleccionado != null)
            {
                // Actualizar el objeto clienteSeleccionado con los datos modificados
                estuadianteSeleccionado.nombres = txtNombresEstudiantes.Text;
                estuadianteSeleccionado.apellidos = txtApellidosEstudiante.Text;
                estuadianteSeleccionado.fecha_nacimiento = fechaNacPicker.Value;
                estuadianteSeleccionado.correo = txtCorreoEstudiantes.Text;
                estuadianteSeleccionado.direccion = txtDireccionEstudiantes.Text;

                // Llamar al método de la lógica para editar el cliente
                estudianteLogica.EditarEstudiante(estuadianteSeleccionado);

                // Actualizar la vista con los clientes actualizados
                CargarEstudiantes();
                CargarComboEstudiantes();

                // Limpiar los campos después de editar
                LimpiarCamposEstudiante();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cliente para editar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listadoEstudiantes_SelectionChanged(object sender, EventArgs e)
        {
            // Manejar el evento de cambio de selección en el DataGridView
            if (listadoEstudiantes.SelectedRows.Count > 0)
            {
                // Obtener el cliente seleccionado de la fila actual
                estuadianteSeleccionado = (Estudiantes)listadoEstudiantes.SelectedRows[0].DataBoundItem;

                // Mostrar los datos del cliente en los TextBox
                txtNombresEstudiantes.Text = estuadianteSeleccionado.nombres;
                txtApellidosEstudiante.Text = estuadianteSeleccionado.apellidos;
                fechaNacPicker.Value = estuadianteSeleccionado.fecha_nacimiento;
                txtCorreoEstudiantes.Text = estuadianteSeleccionado.correo;
                txtDireccionEstudiantes.Text = estuadianteSeleccionado.direccion;
            }
        }

        private void btnEliminarEstudiante_Click(object sender, EventArgs e)
        {
            if (estuadianteSeleccionado != null)
            {
                // Mostrar un cuadro de diálogo de confirmación
                DialogResult resultado = MessageBox.Show("¿Está seguro de que desea eliminar este cliente?", "Confirmación de Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Llamar al método de la lógica para eliminar el cliente
                    estudianteLogica.EliminarEstudiante(estuadianteSeleccionado.ID_estudiante);

                    // Actualizar la vista con los clientes actualizados
                    CargarEstudiantes();
                    CargarComboEstudiantes();

                    // Limpiar los campos después de eliminar
                    LimpiarCamposEstudiante();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cliente para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //PROFESORES

        private void LimpiarCamposProfesores()
        {
            txtNombreProfesor.Text = string.Empty;
            txtApellidosProfesores.Text = string.Empty;
            txtCorreoProfesores.Text = string.Empty;
            txtDireccionProfesores.Text = string.Empty;
        }

        private void btnNuevaMatricula_Click(object sender, EventArgs e)
        {
            LimpiarCamposMatricula();
        }

        private void LimpiarCamposMatricula()
        {
            // Limpiar los campos del formulario
            comboEstudiantes.SelectedIndex = -1;
            comboCursos.SelectedIndex = -1;
            fechaMatriculaPicker.Value = DateTime.Now;
            txtEstado.Text = string.Empty;
            

            // Limpiar la variable de producto seleccionado
            estuadianteSeleccionado = null;
        }

        private void btnGuardarMatricula_Click(object sender, EventArgs e)
        {
            // Validaciones de datos antes de guardar (puedes personalizar según tus necesidades)

            if (comboEstudiantes.SelectedIndex == -1 || comboCursos.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // Crear un nuevo objeto Producto con los datos del formulario
            Matriculas nuevoMatricula = new Matriculas
            {
                ID_estudiante = Convert.ToInt32(comboEstudiantes.SelectedValue),
                ID_curso = Convert.ToInt32(comboCursos.SelectedValue),
                fecha_matricula = fechaMatriculaPicker.Value,
                estado = Convert.ToString(txtEstado.Text)
                
            };

            // Llamar al método de la lógica para insertar el nuevo producto
            matriculaLogica.InsertarMatricula(nuevoMatricula);

            // Actualizar la vista con los productos actualizados
            CargarMatriculas();

            // Limpiar los campos después de guardar
            LimpiarCamposMatricula();
        }

        private void btnMatriculas_Click(object sender, EventArgs e)
        {
            panelEstudiantes.Visible = false;
            panelProfesores.Visible = false;
            panelMatricula.Visible = true;
            panelCursos.Visible = false;
        }

        private void btnNuevoProfesor_Click(object sender, EventArgs e)
        {
            LimpiarCamposProfesores();
        }

        private void btnGuardarProfesor_Click(object sender, EventArgs e)
        {
            // Validaciones de datos antes de guardar (puedes personalizar según tus necesidades)
            if (string.IsNullOrEmpty(txtNombreProfesor.Text) || string.IsNullOrEmpty(txtApellidosProfesores.Text) || string.IsNullOrEmpty(txtCorreoProfesores.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Error de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Profesores nuevoProfesor = new Profesores
            {
                nombres = txtNombreProfesor.Text,
                apellidos = txtApellidosProfesores.Text,
                correo = txtCorreoProfesores.Text,
                direccion = txtDireccionEstudiantes.Text
            };

            // Llamar al método de la lógica para insertar el nuevo cliente
            profesorLogica.InsertarProfesores(nuevoProfesor);

            // Actualizar la vista con los clientes actualizados
            CargarProfesores();
            CargarComboProfesores();

            // Limpiar los campos después de guardar
            LimpiarCamposProfesores();
        }

        private void btnEditarProfesor_Click(object sender, EventArgs e)
        {
            if (profesorSeleccionado != null)
            {
                // Actualizar el objeto clienteSeleccionado con los datos modificados
                profesorSeleccionado.nombres = txtNombreProfesor.Text;
                profesorSeleccionado.apellidos = txtApellidosProfesores.Text;
                profesorSeleccionado.correo = txtCorreoProfesores.Text;
                profesorSeleccionado.direccion = txtDireccionProfesores.Text;

                // Llamar al método de la lógica para editar el cliente
                profesorLogica.EditarProfesores(profesorSeleccionado);

                // Actualizar la vista con los clientes actualizados
                CargarProfesores();
                CargarComboProfesores();

                // Limpiar los campos después de editar
                LimpiarCamposProfesores();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un profesor para editar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarProfesor_Click(object sender, EventArgs e)
        {
            if (profesorSeleccionado != null)
            {
                // Mostrar un cuadro de diálogo de confirmación
                DialogResult resultado = MessageBox.Show("¿Está seguro de que desea eliminar este profesor?", "Confirmación de Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Llamar al método de la lógica para eliminar el cliente
                    profesorLogica.EliminarProfesores(profesorSeleccionado.ID_profesor);

                    // Actualizar la vista con los clientes actualizados
                    CargarProfesores();
                    CargarComboProfesores();

                    // Limpiar los campos después de eliminar
                    LimpiarCamposProfesores();
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un profesor para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listadoProfesores_SelectionChanged(object sender, EventArgs e)
        {
            // Manejar el evento de cambio de selección en el DataGridView
            if (listadoProfesores.SelectedRows.Count > 0)
            {
                // Obtener el cliente seleccionado de la fila actual
                profesorSeleccionado = (Profesores)listadoProfesores.SelectedRows[0].DataBoundItem;

                // Mostrar los datos del cliente en los TextBox
                txtNombreProfesor.Text = profesorSeleccionado.nombres;
                txtApellidosProfesores.Text = profesorSeleccionado.apellidos;
                txtCorreoProfesores.Text = profesorSeleccionado.correo;
                txtDireccionProfesores.Text = profesorSeleccionado.direccion;
            }
        }

        private void btnCursos_Click(object sender, EventArgs e)
        {
            panelCursos.Visible = true;
            
            
        }

        private void listadoCursos_SelectionChanged(object sender, EventArgs e)
        {
            if (listadoCursos.SelectedRows.Count > 0)
            {
                // Obtener el cliente seleccionado de la fila actual
                cursoSeleccionado = (Cursos)listadoCursos.SelectedRows[0].DataBoundItem;

                // Mostrar los datos del cliente en los TextBox
                txtNombreCurso.Text = cursoSeleccionado.nombre_curso;
                txtDescripcionCurso.Text = cursoSeleccionado.descripcion;
                txtCreditosCurso.Text = cursoSeleccionado.creditos.ToString();
                comboProfesor.SelectedValue = cursoSeleccionado.ID_Profesor;
            }
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            panelEstudiantes.Visible = false;
            panelProfesores.Visible = false;
            panelMatricula.Visible = false;
            panelCursos.Visible = false;
        }

        private void btnHorario_Click(object sender, EventArgs e)
        {

        }
    }
}
