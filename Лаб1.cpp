#include <iostream>
#include <fstream>
#include <vector>
#include <cmath>
#include <iomanip>

using namespace std;

struct Row {
    double x, t, u;
};

vector<Row> table1, table2, table3;

bool readTable(const string& filename, vector<Row>& table) {
    ifstream file(filename);
    if (!file.is_open()) return false;
    Row row;
    while (file >> row.x >> row.t >> row.u) {
        table.push_back(row);
    }
    return true;
}

double interpolate(double x, const vector<Row>& table, bool isT) {
    if (table.empty()) {
        cerr << "Error: Table is Empty!" << endl;
        return 0;
    }
    for (size_t i = 0; i + 1 < table.size(); ++i) {
        if (table[i].x <= x && x <= table[i + 1].x) {
            double x1 = table[i].x, x2 = table[i + 1].x;
            double y1 = isT ? table[i].t : table[i].u;
            double y2 = isT ? table[i + 1].t : table[i + 1].u;
            return y1 + (y2 - y1) * (x - x1) / (x2 - x1);
        }
    }
    return isT ? table.back().t : table.back().u;
}

double Sr(double x, double y, double z) {
    if (x > y) return interpolate(x, table1, true) + interpolate(z, table1, false) - interpolate(y, table1, true);
    else return interpolate(y, table1, true) + interpolate(x, table1, false) - interpolate(z, table1, false);
}

double Gold(double x, double y) {
    if (x > y && y != 0) return x / y;
    else if (y > x && x != 0) return y / x;
    else return 0;
}

double Glr(double x, double y) {
    double expr = sqrt(x * x + y * y - 4);
    if (fabs(x) >= 1 && fabs(y) < 1) return x;
    if (fabs(x) < 1 && fabs(y) >= 1) return y;
    if (expr >= 0.1) return expr;
    return 0;
}

double Grs(double x, double y) {
    return 0.1389 * Sr(x + y, Gold(x, y), Glr(x, x * y)) +
        1.8389 * Sr(x - y, Gold(x, y / 5), Glr(5 * x, x * y)) +
        0.833 * Sr(x - 0.9, Glr(y, x / 5), Gold(5 * y, y));
}

double fun1(double x, double y, double z) {
    return x * x * Grs(y, z) + y * y * Grs(x, z) + 0.33 * x * y * Grs(x, z);
}

double Grs1(double x, double y) {
    return 0.14 * Sr(x + y, Gold(x, y), Glr(x, x * y)) +
        1.83 * Sr(x - y, Gold(x, y / 5), Glr(4 * x, x * y)) +
        0.83 * Sr(x, Glr(1 / y, x / 4), Gold(1 / 4 * y, y));
}

double fun2(double x, double y, double z) {
    return x * x * Grs1(y, z) + y * y * Grs1(x, z) + z * z * Grs1(x, z);
}

double fun3(double x, double y) {
    return 1.3498 * y + 2.2362 * y - 2.348 * x * y;
}

double calculateFun(double x, double y, double z) {
    double rad = sqrt(x * x + y * y - 4);
    if (rad < 0.1)
        return fun3(x, y);
    else
        return fun1(x, y, z);
}

int main() {
    if (!readTable("dat_X_1_1.dat", table1)) {
        cout << "Error of reading dat_X_1_1.dat\n";
        return 1;
    }
    if (!readTable("dat_X1_00.dat", table2)) {
        cout << "Error of reading dat_X1_00.dat\n";
        return 1;
    }
    if (!readTable("dat_X00_1.dat", table3)) {
        cout << "Error of reading dat_X00_1.dat\n";
        return 1;
    }

    double x, y, z;
    cout << "Enter x, y, z: ";
    cin >> x >> y >> z;

    double result = calculateFun(x, y, z);
    cout << fixed << setprecision(5);
    cout << "Result fun(x, y, z) = " << result << endl;

    return 0;
}
