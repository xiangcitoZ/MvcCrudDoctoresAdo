
using MvcCrudDoctoresAdo.Models;
using System.Data.SqlClient;

namespace MvcCrudDoctoresAdo.Respository
{
    public class RespositoryDoctor
    {
        private SqlConnection cn;
        private SqlCommand com;
        private SqlDataReader reader;

        public RespositoryDoctor()
        {
            string connectionString =
               @"Data Source=LOCALHOST\DESARROLLO;Initial Catalog=HOSPITAL;User ID=SA;Password=MCSD2023";
            this.cn = new SqlConnection(connectionString);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;

        }

        public List<Doctor> GetDoctores()
        {
            string sql = "SELECT * FROM Doctor";
            this.com.CommandType = System.Data.CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<Doctor> doctores = new List<Doctor>();
            while (this.reader.Read())
            {
                Doctor doctor = new Doctor();
                doctor.IdHospital = int.Parse(this.reader["HOSPITAL_COD"].ToString());
                doctor.IdDoctor = int.Parse(this.reader["DOCTOR_NO"].ToString());
                doctor.Apellido = this.reader["APELLIDO"].ToString();
                doctor.Especialidad = this.reader["ESPECIALIDAD"].ToString();
                doctor.Salario = int.Parse(this.reader["SALARIO"].ToString());

                doctores.Add(doctor);

            }
            this.reader.Close();
            this.cn.Close();
            return doctores;

        }

        public Doctor FindDoctor(int id)
        {
            string sql = "SELECT * FROM Doctor WHERE DOCTOR_NO = @DOCTOR_NO";
            SqlParameter pamid = new SqlParameter("@DOCTOR_NO", id);
            this.com.Parameters.Add(pamid);
            this.com.CommandType = System.Data.CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            Doctor doctor = new Doctor();
            this.reader.Read();
            doctor.IdHospital = int.Parse(this.reader["HOSPITAL_COD"].ToString());
            doctor.IdDoctor = int.Parse(this.reader["DOCTOR_NO"].ToString());
            doctor.Apellido = this.reader["APELLIDO"].ToString();
            doctor.Especialidad = this.reader["ESPECIALIDAD"].ToString();
            doctor.Salario = int.Parse(this.reader["SALARIO"].ToString());

            this.reader.Close();
            this.cn.Close();
            this.com.Parameters.Clear();
            return doctor;

        }

        public void InsertDoctor(int idhospital, int iddoctor, string apellido, string especialidad, int salario)
        {
            string sql = "INSERT INTO DOCTOR VALUES (@IDHOSPITAL, @IDDOCTOR, @APELLIDO, @ESPECIALIDAD, @SALARIO)";
            SqlParameter pamidhospital = new SqlParameter("@IDHOSPITAL", idhospital);
            SqlParameter pamiddoctor = new SqlParameter("@IDDOCTOR", iddoctor);
            SqlParameter pamapellido= new SqlParameter("@APELLIDO", apellido);
            SqlParameter pamespecialidad= new SqlParameter("@ESPECIALIDAD", especialidad);
            SqlParameter pamsalario = new SqlParameter("@SALARIO", salario);
            this.com.Parameters.Add(pamidhospital);
            this.com.Parameters.Add(pamiddoctor);
            this.com.Parameters.Add(pamapellido);
            this.com.Parameters.Add(pamespecialidad);
            this.com.Parameters.Add(pamsalario);
            this.com.CommandType = System.Data.CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
        }

        public void UpdateDoctor(int idhospital, int iddoctor, string apellido, string especialidad, int salario)
        {
            string sql = "UPDATE DOCTOR SET HOSPITAL_COD=@HOSPITAL_COD, APELLIDO=@APELLIDO, ESPECIALIDAD=@ESPECIALIDAD , " +
                "SALARIO = @SALARIO WHERE DOCTOR_NO=@DOCTOR_NO";
            SqlParameter pamidhospital = new SqlParameter("@HOSPITAL_COD", idhospital);
            SqlParameter pamiddoctor = new SqlParameter("@DOCTOR_NO", iddoctor);
            SqlParameter pamapellido = new SqlParameter("@APELLIDO", apellido);
            SqlParameter pamespecialidad = new SqlParameter("@ESPECIALIDAD", especialidad);
            SqlParameter pamsalario = new SqlParameter("@SALARIO", salario);
            this.com.Parameters.Add(pamidhospital);
            this.com.Parameters.Add(pamiddoctor);
            this.com.Parameters.Add(pamapellido);
            this.com.Parameters.Add(pamespecialidad);
            this.com.Parameters.Add(pamsalario);

            this.com.CommandType = System.Data.CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
        }

        public void DeleteDoctor(int id)
        {
            string sql = "DELETE FROM DOCTOR WHERE DOCTOR_NO=@DOCTOR_NO";
            SqlParameter pamid = new SqlParameter("@DOCTOR_NO", id);

            this.com.Parameters.Add(pamid);

            this.com.CommandType = System.Data.CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
        }


        public List<Hospital> GetHospitales()
        {
            string sql = "SELECT * FROM HOSPITAL";
            this.com.CommandType = System.Data.CommandType.Text;
            this.com.CommandText = sql;
            this.cn.Open();
            this.reader = this.com.ExecuteReader();
            List<Hospital> hospitales = new List<Hospital>();
            while (this.reader.Read())
            {
                Hospital hospital = new Hospital();
                hospital.IdHospital = int.Parse(this.reader["HOSPITAL_COD"].ToString());
                hospital.Nombre = this.reader["NOMBRE"].ToString();
                hospital.Direccion = this.reader["DIRECCION"].ToString();
                hospital.Telefono = this.reader["TELEFONO"].ToString();
                hospital.Camas = int.Parse(this.reader["NUM_CAMA"].ToString());
                hospitales.Add(hospital);

            }
            this.reader.Close();
            this.cn.Close();
            return hospitales;

        }



    }
}
