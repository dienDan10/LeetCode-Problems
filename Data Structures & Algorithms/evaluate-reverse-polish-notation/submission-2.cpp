class Solution {
public:
    int evalRPN(vector<string>& tokens) {
        std::stack<int> st{};

        for (const auto& s : tokens) {
            if (s != "+" && s != "-" && s != "*" && s != "/") {
                st.push(std::stoi(s));
                continue;
            }

            int b = st.top();
            st.pop();
            int a = st.top();
            st.pop();
            int result = calculate(a, b, s.at(0));
            st.push(result);
        }

        return st.top();
    }

    int calculate(int a, int b, char oper) {
        switch (oper) {
            case '+':
                return a + b;
            case '-':
                return a - b;
            case '*':
                return a * b;
            case '/':
                return a / b;
            default:
                return 0;
        }
    }
};
