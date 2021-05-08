﻿using System;

namespace RefactoringGuru.DesignPatterns.Adapter.Structural
{
    // / <summary>
    // a class into the interface clients expect.
    // together where they otherwise couldn't, due to incompatible interfaces.
    // / 
    // интерфейсу другого класса.
    // другом, даже если их интерфейсы несовместимы.


    // / <summary>
    // / RU: ITarget определяет интерфейс, с которым может работать клиент.
    // </summary>
    interface ITarget
    {
        string GetRequest();
    }

    // / <summary>
    // interface is incompatible
    // needs some adaptation before the client code can use it.
    // Adaptee содержит полезные методы, но его интерфейс несовместим с тем,
    // который
    // адаптации для того,
    class Adaptee
    {
        public string GetSpecificRequest()
        {
            return "Specific request.";
        }
    }

    // / <summary>
    // with the ITarget interface. 
    // интерфейс Adaptee к ожидаемому клиентом интерфейсу ITarget.
    class Adapter : ITarget
    {
        private readonly Adaptee _adaptee;

        public Adapter(Adaptee adaptee)
        {
            _adaptee = adaptee;
        }

        public string GetRequest()
        {
            return $"This is '{_adaptee.GetSpecificRequest()}'";
        }
    }

    class Client
    {
        public void Main()
        {
            Adaptee adaptee = new Adaptee();

            ITarget target = new Adapter(adaptee);

            Console.WriteLine("Adaptee interface is incompatible with the client.");
            Console.WriteLine("But with adapter client can call it's method.");

            Console.WriteLine(target.GetRequest());
        }
    }

    class Program
    {
        static void Main()
        {
            new Client().Main();
        }
    }
}