# TaskFlow360 – Smart Task Manager Backend

TaskFlow360 is a modular, scalable **.NET 8 Web API** designed using **Clean Architecture**, **CQRS**, and **MediatR**. It serves as the backend for a smart task manager system, where users can manage tasks and receive reminders via Azure Functions.

---

## 🧰 Tech Stack

- **.NET 8** Web API
- **Clean Architecture**
- **CQRS + MediatR v12**
- **In-memory Repository** (swap-ready with EF Core or Cosmos DB)
- **Swagger** for API testing
- Ready for **React frontend** and **Azure Functions**

---

## 📁 Project Structure

TaskFlow360/ ├── backend/ │ ├── TaskFlow360.API/ → Entry point, controllers │ ├── TaskFlow360.Application/ → Commands, Queries, DTOs │ ├── TaskFlow360.Domain/ → Entities, Interfaces │ └── TaskFlow360.Infrastructure/→ In-memory repository

---

## 🧪 API Endpoints

| Method | Endpoint           | Description            |
|--------|--------------------|------------------------|
| GET    | /api/tasks         | List all tasks         |
| POST   | /api/tasks         | Add new task           |
| PUT    | /api/tasks/{id}    | Update task by ID      |
| DELETE | /api/tasks/{id}    | Delete task by ID      |

Test these using Swagger at `https://localhost:{port}/swagger`.

---

## 🧠 Learning Timeline

See [`LEARNING_LOG.md`](./LEARNING_LOG.md) for a breakdown of my learning journey and how this project came together.

---

## 🧱 What's Next

- Connect React frontend (TaskFlow360 Client)
- Integrate Azure Function Timer Trigger for task reminders
- Add real persistence (EF Core, Azure Cosmos DB)
- Unit & integration tests

---

## 📜 License

MIT