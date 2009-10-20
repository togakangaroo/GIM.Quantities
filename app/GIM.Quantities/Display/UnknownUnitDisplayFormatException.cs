using System;

namespace GIM.Quantities.Display {
    public class UnknownUnitDisplayFormatException : InvalidOperationException {
        public UnknownUnitDisplayFormatException(string requestedFormat, IProvideUnitDisplays repository)
            : base("Specified format {0} is unknown".Use(requestedFormat)) {
            Repository = repository;
            RequestedFormat = requestedFormat;
        }
        public IProvideUnitDisplays Repository { get; private set; }
        public object RequestedFormat { get; private set; }
    }
}
