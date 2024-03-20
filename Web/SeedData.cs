using ApplicationCore.Interfaces.Repository;
using BackendLab01;

namespace Infrastructure.Memory;
public static class SeedData
{
    public static void Seed(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var provider = scope.ServiceProvider;
            var quizRepo = provider.GetService<IGenericRepository<Quiz, int>>();
            var quizItemRepo = provider.GetService<IGenericRepository<QuizItem, int>>();
            
            var quiz1 = new Quiz(
                    id: 1,
                    items: new List<QuizItem>
                    {
                        new QuizItem(
                            id: 1,
                            question: "Miasto w którym jesteś ?",
                            incorrectAnswers: new List<string> {"Warszawa", "Wadowice", "Wieliczka"},
                            correctAnswer: "Kraków"
                        ),
                        new QuizItem(
                            id: 2,
                            question: "Na którym jesteśmy semestrze",
                            incorrectAnswers: new List<string> {"3", "2", "1"},
                            correctAnswer: "4"
                        ),
                        new QuizItem(
                            id: 3,
                            question: "Stolica Rosji?",
                            incorrectAnswers: new List<string> {"Petersburg", "Kijów", "Kraków"},
                            correctAnswer: "Moskwa"
                        )
                    },
                    title: "Quiz 1"
                );

            var quiz2 = new Quiz(
                    id: 2,
                    items: new List<QuizItem>
                    {
                        new QuizItem(
                            id: 1,
                            question: "Stolica Czech?",
                            incorrectAnswers: new List<string> {"Bratyslawa", "Warszawa", "Kijówe"},
                            correctAnswer: "Praga"
                        ),
                        new QuizItem(
                            id: 2,
                            question: "Z kim nie graniczy Polska?",
                            incorrectAnswers: new List<string> {"Słowacja", "Ukraina", "Niemcy"},
                            correctAnswer: "Włochy"
                        ),
                        new QuizItem(
                            id: 3,
                            question: "Najlepsza uczelnia?",
                            incorrectAnswers: new List<string> {"AGH", "UJ", "UEK"},
                            correctAnswer: "WSEI"
                        )
                    },
                    title: "Quiz 2"
                );

                quizRepo.Add(quiz1);
                quizRepo.Add(quiz2);
            }
        }
    }