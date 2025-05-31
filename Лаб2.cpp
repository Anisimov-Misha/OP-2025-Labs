#include <iostream>
#include <thread>
#include <mutex>
#include <vector>
#include <memory>
#include <cmath>
#include <chrono>

#ifndef M_PI
#define M_PI 3.14159265358979323846
#endif

std::mutex cout_mutex;  // Для потокобезпечного виводу

// Мураха-робоча: рух вперед (до [0,0]) і назад (до точки народження)
struct AntWorker {
    int id;
    double speed;       // швидкість (умовні одиниці)
    double startX, startY;  // початкова точка
    double posX, posY;      // поточна позиція
    bool movingForward;     // напрямок руху

    AntWorker(int id_, double speed_, double x_, double y_)
        : id(id_), speed(speed_), startX(x_), startY(y_), posX(x_), posY(y_), movingForward(true) {}

    // Забороняємо копіювання і переміщення
    AntWorker(const AntWorker&) = delete;
    AntWorker& operator=(const AntWorker&) = delete;
    AntWorker(AntWorker&&) = delete;
    AntWorker& operator=(AntWorker&&) = delete;

    void move() {
        double targetX = 0.0;
        double targetY = 0.0;

        while (true) {
            if (movingForward) {
                // рухаємося до (0,0)
                double dx = targetX - posX;
                double dy = targetY - posY;
                double dist = std::sqrt(dx * dx + dy * dy);

                if (dist < 0.01) { // досягли точки
                    movingForward = false;
                    std::lock_guard<std::mutex> lock(cout_mutex);
                    std::cout << "[Worker " << id << "] Reached point (0,0), turning back\n";
                }
                else {
                    posX += speed * dx / dist;
                    posY += speed * dy / dist;
                }
            }
            else {
                // рухаємося назад до стартової точки
                double dx = startX - posX;
                double dy = startY - posY;
                double dist = std::sqrt(dx * dx + dy * dy);

                if (dist < 0.01) { // повернулися назад
                    movingForward = true;
                    std::lock_guard<std::mutex> lock(cout_mutex);
                    std::cout << "[Worker " << id << "] Back to the start (" << startX << "," << startY << ")\n";
                }
                else {
                    posX += speed * dx / dist;
                    posY += speed * dy / dist;
                }
            }

            {
                std::lock_guard<std::mutex> lock(cout_mutex);
                std::cout << "[Worker " << id << "] Position: (" << posX << ", " << posY << ")\n";
            }

            std::this_thread::sleep_for(std::chrono::milliseconds(200));
        }
    }
};

// Мураха-воїн: рух по колу радіусом R зі швидкістю V
struct AntWarrior {
    int id;
    double speed;    // кутова швидкість (радіани за крок)
    double radius;
    double angle;    // поточний кут

    AntWarrior(int id_, double speed_, double radius_)
        : id(id_), speed(speed_), radius(radius_), angle(0) {}

    // Забороняємо копіювання і переміщення
    AntWarrior(const AntWarrior&) = delete;
    AntWarrior& operator=(const AntWarrior&) = delete;
    AntWarrior(AntWarrior&&) = delete;
    AntWarrior& operator=(AntWarrior&&) = delete;

    void move() {
        while (true) {
            angle += speed;
            if (angle > 2 * M_PI) angle -= 2 * M_PI;

            double posX = radius * std::cos(angle);
            double posY = radius * std::sin(angle);

            {
                std::lock_guard<std::mutex> lock(cout_mutex);
                std::cout << "[Warrior " << id << "] Position: (" << posX << ", " << posY << ")\n";
            }

            std::this_thread::sleep_for(std::chrono::milliseconds(200));
        }
    }
};

int main() {
    const int NUM_WORKERS = 3;
    const int NUM_WARRIORS = 2;

    std::vector<std::unique_ptr<AntWorker>> workers;
    std::vector<std::unique_ptr<AntWarrior>> warriors;

    // Ініціалізація мурах-робочих із стартовими точками
    workers.emplace_back(std::make_unique<AntWorker>(1, 0.1, 5.0, 5.0));
    workers.emplace_back(std::make_unique<AntWorker>(2, 0.15, 10.0, 3.0));
    workers.emplace_back(std::make_unique<AntWorker>(3, 0.12, 7.0, 8.0));

    // Ініціалізація мурах-воїнів
    warriors.emplace_back(std::make_unique<AntWarrior>(1, 0.1, 5.0));
    warriors.emplace_back(std::make_unique<AntWarrior>(2, 0.15, 3.0));

    std::vector<std::thread> threads;

    // Запускаємо потоки для мурах-робочих
    for (auto& w : workers) {
        threads.emplace_back(&AntWorker::move, w.get());
    }

    // Запускаємо потоки для мурах-воїнів
    for (auto& w : warriors) {
        threads.emplace_back(&AntWarrior::move, w.get());
    }

    // Чекаємо, поки всі потоки завершаться (у нас цього не буде, бо цикли безкінечні)
    for (auto& t : threads) {
        t.join();
    }

    return 0;
}
