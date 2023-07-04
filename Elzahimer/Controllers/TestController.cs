using Elzahimer.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Model.core;
using Model.core.Interface;

namespace Elzahimer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IUnitOfWorkRepository unitOfWorkRepository;
        private readonly IAnswerRepository answerRepository;


        public TestController(IUnitOfWorkRepository unitOfWorkRepository, IAnswerRepository answerRepository)
        {
            this.unitOfWorkRepository = unitOfWorkRepository;
            this.answerRepository = answerRepository;
        }


        [HttpPost("AddTest")]
        public async Task<IActionResult> AddTest(TestDTO testDTO) {
           Test test = new Test();
            if (ModelState.IsValid)
            {
                test.title = testDTO.title;
                test.minDegree = testDTO.minDegree;
                test.middleDegree = testDTO.middleDegree;
                test.MaxDegree = testDTO.MaxDegree;
                await unitOfWorkRepository.Test.AddAsync(test);
                return Ok(test.id);
            }
            return BadRequest();
        }

        [HttpGet("GetAllTests")]
        public async Task<IActionResult> GetallExams()
        {
          List<Test>tests=(List<Test>) await unitOfWorkRepository.Test.GetAllAsync();
            return Ok(tests);
        }

        [HttpGet("GetTestById")]
        public async Task<IActionResult> GetTestById(int id)
        {
           Test tests = await unitOfWorkRepository.Test.GetByIdAsync(id);
            return Ok(tests);
        }
        [HttpDelete("DeleteTest")]
        public async Task<IActionResult> DeleteTest(int id)
        {
          Test test=  await unitOfWorkRepository.Test.GetByIdAsync(id);
            test.IsDeleted= true;
            unitOfWorkRepository.Test.Delete(test);
            return Ok("Deleted");
        }

        [HttpPost("AddQuestion")]
        public async Task<IActionResult> AddQuestion(QuestioDTO questioDTO)
        {
            Question question = new Question();
            List<Answer> answerList = new List<Answer>();
            if (ModelState.IsValid)
            {
                question.TestId= questioDTO.TestId;
                question.question = questioDTO.question;
                questioDTO.Id= question.Id;
                await unitOfWorkRepository.Question.AddAsync(question);
                //foreach(var answer in questioDTO.Answers) {
                //    answerList.Add( new Answer
                //    {
                //        QuestionID= question.Id,
                //        Ans=answer.Ans,
                //        Score=answer.Score,
                //    }                 
                //    );                 
                // }
                foreach(Answer answer in answerList)
                {
                    await unitOfWorkRepository.Answer.AddAsync(answer);
                }
              return Ok(question.Id);
            }
            return BadRequest();
        }

        [HttpGet("GetAllQuestions")]
        public async Task<IActionResult> GetAllQuestions(int testId)
        { 
            List<Question> questions=  unitOfWorkRepository.QuesionRepository.GetAllQuestions(testId);
              Console.WriteLine("Number of questions retrieved: " + questions.Count);
            List<QuestioDTO> questioDTOs = new List<QuestioDTO>();
                foreach (Question question in questions)
                {
                    QuestioDTO questioDTO = new QuestioDTO();
                    questioDTO.TestId = testId;
                    questioDTO.question= question.question;
                    questioDTO.Id=question.Id;
                   //questioDTO.Answers = new List<AnswerDTO>();
                   // foreach (Answer answer in question.Answers)
                   // {
                   //     questioDTO.Answers.Add(new AnswerDTO
                   //     {
                   //         Ans = answer.Ans,
                   //         Score = answer.Score,
                   //     });
                   // }

                   questioDTOs.Add(questioDTO);
                }

            return Ok(questioDTOs);
           
        }


        [HttpPost("GetFinalScore")]
        public async Task<IActionResult> GetFinalScore(AnswerUserDto answerUserDto)
        {
            int score = 0;
            Test test = unitOfWorkRepository.QuesionRepository.Test(answerUserDto.ExamId);
            foreach(Question q in test.questions)
            {
                foreach(QAns qAns in answerUserDto.QAns)
                {
                    if(q.Id== qAns.QId)
                    {
                       foreach(Answer correct in q.Answers)
                        {
                            if (correct.Ans == qAns.AnswerUser)
                            {
                                score=score+correct.Score;
                            }
                        }

                    }
                }

            }
            //List<Question> questions = unitOfWorkRepository.QuesionRepository.GetAllQuestions(testId);
            //List<QuestioDTO> questioDTOs = new List<QuestioDTO>();
            //int finalScore = 0;
            //foreach (Question question in questions)
            //{
            //    foreach (Answer answer in question.Answers)
            //    {
            //       finalScore += answer.Score;
                    
            //    }
             
            //}

            return Ok(score);

        }




        //***********************reeem && eman ********************************
        [HttpGet("GetAllAnswer")]
        public async Task<IActionResult> GetAllAnswer(int qesid)
        {
            List<Answer> answers = answerRepository.GetAllAnswer(qesid);
            return Ok(answers);
        }
        [HttpPost("Addanswer")]
        public async Task<IActionResult> Addanswer(AnswerDTO answerDTO1)
        {
            Answer answer= new Answer();
            //Test test = new Test();
            if (ModelState.IsValid)
            {
                answer.Ans = answerDTO1.Ans;
                answer.Score = answerDTO1.Score;
                answer.QuestionID = answerDTO1.QuestionID;
                //answer.id = answerDTO1.id;
                //answer.Question.TestId=answerDTO1.TestId;
                await unitOfWorkRepository.Answer.AddAsync(answer);
                return Ok(answer);
            }
            return BadRequest();
        }

    }
}
