﻿using Members.CoreBusiness;
using Members.UseCases.Interfaces;
using Members.UseCases.PluginInterfaces;

namespace Members.UseCases.StudentUsecases
{
    public class EditStudentUseCase : IEditStudentUseCase {
        private readonly IStudentRepository _studentRepository;

        public EditStudentUseCase(IStudentRepository studentRepository) {
            _studentRepository = studentRepository;
        }
        public async Task ExecuteAsync(int studentId, Student student) {
            await _studentRepository.UpdateStudent(studentId, student);
        }
    }
}
