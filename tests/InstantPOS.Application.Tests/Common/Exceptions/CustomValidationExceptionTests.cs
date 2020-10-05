using System;
using System.Collections.Generic;
using FluentAssertions;
using FluentValidation.Results;
using InstantPOS.Application.Common.Exceptions;
using Xunit;

namespace InstantPOS.Application.Tests.Common.Exceptions
{
    public class CustomValidationExceptionTests
    {
        [Fact]
        public void DefaultConstructorCreatesAnEmptyErrorDictionary()
        {
            var actual = new CustomValidationException().Errors;

            actual.Keys.Should().BeEquivalentTo(Array.Empty<string>());
        }

        [Fact]
        public void SingleValidationFailureCreatesASingleElementErrorDictionary()
        {
            var failures = new List<ValidationFailure>
            {
                new ValidationFailure("Age", "must be over 18"),
            };

            var actual = new CustomValidationException(failures).Errors;

            actual.Keys.Should().BeEquivalentTo(new string[] { "Age" });
            actual["Age"].Should().BeEquivalentTo(new string[] { "must be over 18" });
        }

        [Fact]
        public void MulitpleValidationFailureForMultiplePropertiesCreatesAMultipleElementErrorDictionaryEachWithMultipleValues()
        {
            var failures = new List<ValidationFailure>
            {
                new ValidationFailure("Age", "must be 18 or older"),
                new ValidationFailure("Age", "must be 25 or younger"),
                new ValidationFailure("Password", "must contain at least 8 characters"),
                new ValidationFailure("Password", "must contain a digit"),
                new ValidationFailure("Password", "must contain upper case letter"),
                new ValidationFailure("Password", "must contain lower case letter"),
            };

            var actual = new CustomValidationException(failures).Errors;

            actual.Keys.Should().BeEquivalentTo(new string[] { "Password", "Age" });

            actual["Age"].Should().BeEquivalentTo(new string[]
            {
                "must be 25 or younger",
                "must be 18 or older",
            });

            actual["Password"].Should().BeEquivalentTo(new string[]
            {
                "must contain lower case letter",
                "must contain upper case letter",
                "must contain at least 8 characters",
                "must contain a digit",
            });
        }
    }
}
