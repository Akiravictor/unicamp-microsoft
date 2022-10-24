using Avalonia.Animation.Animators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Class3
{

    class Expression { 
        public virtual void Accept(Visitor v)
        {
            v.VisitExpression(this);
        }

        public virtual double GetValue()
        {
            return 0;
        }
    }

    class Number : Expression
    {
        double value;
        public Number(double _value) { value = _value; }

        public override void Accept(Visitor v)
        {
            v.VisitNumber(this);
        }

        public override double GetValue()
        {
            return value;
        }

    }

    class BinaryOp : Expression
    {
        public Expression left;
        public Expression right;
        public BinaryOp(Expression l, Expression r)
        {
            left = l;
            right = r;
        }

        public override void Accept(Visitor v)
        {
            left.Accept(v);
            right.Accept(v);
        }

    }
    class Addition : BinaryOp
    {
        public Addition(Expression l, Expression r) : base(l, r) { }

        public override void Accept(Visitor v)
        {
            v.VisitAddition(this);
        }

        public override double GetValue()
        {
            return left.GetValue() + right.GetValue();
        }
    }
    class Subtraction : BinaryOp
    {
        public Subtraction(Expression l, Expression r) : base(l, r) { }

        public override void Accept(Visitor v)
        {
            v.VisitSubtraction(this);
        }

        public override double GetValue()
        {
            return left.GetValue() - right.GetValue();
        }
    }
    class Multiplication : BinaryOp
    {
        public Multiplication(Expression l, Expression r) : base(l, r) { }

        public override void Accept(Visitor v)
        {
            v.VisitMultiplication(this);
        }

        public override double GetValue()
        {
            return left.GetValue() * right.GetValue();
        }
    }
    class Division : BinaryOp
    {
        public Division(Expression l, Expression r) : base(l, r) { }

        public override void Accept(Visitor v)
        {
            v.VisitDivision(this);
        }

        public override double GetValue()
        {
            return left.GetValue() / right.GetValue();
        }
    }
    class Negation : Expression
    {
        public Expression value;
        public Negation(Expression v) { value = v; }

        public override void Accept(Visitor v)
        {
            v.VisitNegation(this);
        }

        public override double GetValue()
        {
            return -1 * value.GetValue();
        }
    }

    abstract class Visitor
    {
        public abstract void VisitExpression(Expression exp);
        public abstract void VisitNumber(Number exp);
        public abstract void VisitNegation(Negation exp);
        public abstract void VisitAddition(Addition exp);
        public abstract void VisitSubtraction(Subtraction exp);
        public abstract void VisitMultiplication(Multiplication exp);
        public abstract void VisitDivision(Division exp);
    }

    class DepthVisitor : Visitor
    {
        int depth = 0;
        public override void VisitExpression(Expression exp)
        {
            exp.Accept(this);
            depth++;
        }
        public override void VisitNumber(Number exp)
        {
            depth++;
        }
        public override void VisitNegation(Negation exp)
        {
            exp.value.Accept(this);
        }
        public override void VisitAddition(Addition exp)
        {
            exp.left.Accept(this);
            exp.right.Accept(this);
        }
        public override void VisitSubtraction(Subtraction exp)
        {
            exp.left.Accept(this);
            exp.right.Accept(this);
        }
        public override void VisitMultiplication(Multiplication exp)
        {
            exp.left.Accept(this);
            exp.right.Accept(this);
        }
        public override void VisitDivision(Division exp)
        {
            exp.left.Accept(this);
            exp.right.Accept(this);
        }

        public void Depth()
        {
            Console.WriteLine(depth);
        }
    }

    class ResultVisitor : Visitor
    {
        public override void VisitExpression(Expression exp)
        {
            Console.WriteLine($"{exp.GetValue()}");
        }
        public override void VisitNumber(Number exp)
        {
            Console.WriteLine($"{exp.GetValue()}");
        }
        public override void VisitNegation(Negation exp)
        {
            Console.WriteLine($"{exp.GetValue()}");
        }
        public override void VisitAddition(Addition exp)
        {
            Console.WriteLine($"{exp.GetValue()}");
        }
        public override void VisitSubtraction(Subtraction exp)
        {
            Console.WriteLine($"{exp.GetValue()}");
        }
        public override void VisitMultiplication(Multiplication exp)
        {
            Console.WriteLine($"{exp.GetValue()}");
        }
        public override void VisitDivision(Division exp)
        {
            Console.WriteLine($"{exp.GetValue()}");
        }
    }

    class MathVisitor : Visitor
    {
        public override void VisitExpression(Expression exp)
        {
            Console.Write("(");
            exp.Accept(this);
            Console.Write(")");
        }

        public override void VisitNumber(Number num)
        {
            Console.Write(num.GetValue());
        }

        public override void VisitNegation(Negation exp)
        {
            Console.Write($"-1 * (");
            exp.value.Accept(this);
            Console.Write($")");
        }

        public override void VisitAddition(Addition exp)
        {
            Console.Write("(");
            exp.left.Accept(this);
            Console.Write(" + ");
            exp.right.Accept(this);
            Console.Write(")");
        }

        public override void VisitSubtraction(Subtraction exp)
        {
            Console.Write("(");
            exp.left.Accept(this);
            Console.Write(" - ");
            exp.right.Accept(this);
            Console.Write(")");
        }

        public override void VisitMultiplication(Multiplication exp)
        {
            Console.Write("(");
            exp.left.Accept(this);
            Console.Write(" * ");
            exp.right.Accept(this);
            Console.Write(")");
        }

        public override void VisitDivision(Division exp)
        {
            Console.Write("(");
            exp.left.Accept(this);
            Console.Write(" / ");
            exp.right.Accept(this);
            Console.Write(")");
        }
    }

    public class Ex1
    {
        public static void run()
        {
            // Implemente três Visitors que operem na árvore dada.
            // - O primeiro Visitor deve retornar a profundidade da árvore.
            // - O segundo deve retornar o resultado das operações.
            // - O terceiro deve gerar uma string com a árvore em forma de expressão matemática.

            // Por exemplo, para a árvore

            // ```
            // Addition(Number(1), Multiplication(Number(2), Number(3)))
            // ```

            // os resultados devem ser:

            // ```
            // Profundidade: 3
            // Resultado: 7
            // Expressão: (1 + (2 * 3))
            // ```

            // Não é necessário implementar a precedência de operações: use parênteses em todas
            // as operações binárias.

            // Imprima os resultados no console.

            Expression tree =
              new Addition(
                new Number(1),
                new Subtraction(
                  new Number(5),
                  new Negation(
                    new Multiplication(
                      new Number(-3),
                      new Division(
                        new Number(10),
                        new Number(5)
                      )
                    )
                  )
                )
              );

            // 1 + (5 - -(-3 * (10 / 5)))

            // + 1
            //   - 5
            //     - * 3
            //         / 10
            //            5

            //Expression tree =
            //    new Addition(
            //        new Number(1),
            //        new Multiplication(
            //            new Number(2),
            //            new Number(3)
            //        )
            //    );

            var depthVisitor = new DepthVisitor();
            var resultVisitor = new ResultVisitor();
            var mathVisitor = new MathVisitor();

            tree.Accept(depthVisitor);
            Console.Write("Profundidade: ");
            depthVisitor.Depth();

            Console.Write("Resultado: ");
            tree.Accept(resultVisitor);

            Console.Write("Expressao: ");
            tree.Accept(mathVisitor);

            Console.WriteLine();
        }
    }
}