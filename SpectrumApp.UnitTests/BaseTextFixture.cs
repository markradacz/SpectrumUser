#define USE_NUNIT
using System;
using SpectrumApp;
using System.Linq;
using System.Threading.Tasks;
using SpectrumApp.UnitTests.Stubs;

#if USE_NUNIT

	using TestInitialize = NUnit.Framework.SetUpAttribute;
	using TestCleanup = NUnit.Framework.TearDownAttribute;
	using NUnit.Framework;

#else

using Microsoft.VisualStudio.TestTools.UnitTesting;

#endif


namespace SpectrumApp.UnitTests
{
	public class BaseTextFixture
	{

#if USE_NUNIT
		[TestInitialize]
		public void Setup()
#else
		[AssemblyInitialize]
		public static void Setup(TestContext context)
#endif
		{
			//Arrange
			ServiceLocator.Instance.Register<IDataStore<User>, SpectrumDbStub>();
		}

		[TestCleanup]
		public virtual void TearDown()
		{
		}
	}
}
