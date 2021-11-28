using System;
using System.Collections.Generic;

namespace KnowledgeExtraction.Common.Communication
{
    /// <summary>
    /// Represents a subscription to an observer.
    /// </summary>
    internal class Subscribtion<TObserver> : IDisposable
    {
        protected readonly List<IObserver<TObserver>> Observers;
        protected readonly IObserver<TObserver> Observer;

        public Subscribtion(List<IObserver<TObserver>> observers, IObserver<TObserver> observer)
        {
            Observers = observers;
            Observer = observer;
        }

        public virtual void Dispose()
        {
            if (Observer != null && Observers.Contains(Observer))
                Observers.Remove(Observer);
        }
    }
}