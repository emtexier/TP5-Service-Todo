public class SeedData
{
    public void AddData()
    {
        ServiceTodo context = new ServiceTodo();

        // Add todos
        Todo todo1 = new Todo
        {
            Task = "Compléter le projet",
            Completed = false,
            Deadline = DateTime.Parse("2024-10-20")
        };
        Todo todo2 = new Todo
        {
            Task = "Enregistrer la matrice d'implication",
            Completed = true,
            Deadline = DateTime.Parse("2024-09-30")  // deadline passée
        };
        Todo todo3 = new Todo
        {
            Task = "Videoconference",
            Completed = false,
            Deadline = DateTime.Today  // aujourd'hui
        };

        context.Todos.AddRange(
            todo1,
            todo2,
            todo3
        );

        context.SaveChanges();
    }
}
