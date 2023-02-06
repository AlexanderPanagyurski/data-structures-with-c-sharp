namespace Problem04.BalancedParentheses
{
    using System.Collections.Generic;

    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            if (string.IsNullOrEmpty(parentheses) || parentheses.Length % 2 == 1)
            {
                return false;
            }
            var stack = new Stack<char>(parentheses.Length % 2);


            foreach (var currentBracket in parentheses)
            {
                char expectedBracket = default(char);

                switch (currentBracket)
                {
                    case ')':
                        expectedBracket = '(';
                        break;
                    case '}':
                        expectedBracket = '{';
                        break;
                    case ']':
                        expectedBracket = '[';
                        break;
                    default:
                        stack.Push(currentBracket);
                        break;
                }

                if (expectedBracket != default
                     && stack.Pop() != expectedBracket)
                {
                    return false;
                }
            }

            return stack.Count == 0;
        }
    }
}