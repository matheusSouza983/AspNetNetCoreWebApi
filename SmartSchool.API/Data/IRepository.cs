using SmartSchool.API.Models;

namespace SmartSchool.API.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        //ALUNOS
        Aluno[] GetAllAlunos();
        Aluno[] GetAllAlunosByDisciplina();
        Aluno GetAlunobyId();

        //PROFESSORES
        Professor[] GetAllProfessores();
        Professor[] GetAllProfessoresByDisciplina();
        Professor GetProfessorbyId();

    }
}
