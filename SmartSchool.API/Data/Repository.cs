﻿using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Models;
using SQLitePCL;
using System.Linq;

namespace SmartSchool.API.Data
{
    public class Repository : IRepository
    {
        private readonly SmartContext _context;

        public readonly IRepository _repo;
        public Repository(SmartContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }

        public Aluno[] GetAllAlunos(bool includeProfessor)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(a => a.AlunoDisciplinas)
                    .ThenInclude(ad => ad.Disciplina)
                    .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id);
            return query.ToArray();
        }

        public Aluno[] GetAllAlunosByDisciplina(int disciplinaId, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(a => a.AlunoDisciplinas)
                    .ThenInclude(ad => ad.Disciplina)
                    .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking()
                .OrderBy(a => a.Id)
                .Where(aluno => aluno.AlunoDisciplinas.Any(ad => ad.DisciplinaId == disciplinaId));
            return query.ToArray();
        }

        public Aluno GetAlunobyId(int alunoId, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if (includeProfessor)
            {
                query = query.Include(a => a.AlunoDisciplinas)
                    .ThenInclude(ad => ad.Disciplina)
                    .ThenInclude(d => d.Professor);
            }

            query = query.AsNoTracking()
                .OrderBy(a => a.Id)
                .Where(aluno => aluno.Id == alunoId);
            return query.FirstOrDefault();
        }

        public Professor[] GetAllProfessores(bool includeAlunos = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if (includeAlunos)
            {
                query = query.Include(p => p.Disciplinas)
                    .ThenInclude(ad => ad.AlunoDisciplinas)
                    .ThenInclude(d => d.Aluno);
            }

            query = query.AsNoTracking().OrderBy(p => p.Id);
            return query.ToArray();
        }

        public Professor[] GetAllProfessoresByDisciplina(int disciplinaId, bool includeAlunos = false)
        {
            IQueryable<Professor> query = _context.Professores;

            if (includeAlunos)
            {
                query = query.Include(p => p.Disciplinas)
                    .ThenInclude(d => d.AlunoDisciplinas)
                    .ThenInclude(ad => ad.Aluno);
            }

            query = query.AsNoTracking()
                .OrderBy(aluno => aluno.Id)
                .Where(aluno => aluno.Disciplinas.Any(ad => ad. == disciplinaId));
            return query.ToArray();
        }

        public Professor GetProfessorbyId()
        {
            throw new System.NotImplementedException();
        }
    }
}
