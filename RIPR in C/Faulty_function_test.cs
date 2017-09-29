using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sample.Controllers;
using Sample.Models;


namespace Sample.Tests
{
    [TestClass]
    public class Faulty_function_test
    {
        /*
		 * one passes whenever the fault is not reached.
		 * This will be the case when condition c<= min fails : c>min
		 */

        [TestMethod]
        public void TestMethod1()
        {

            var controller = new Faulty_function_controller(0);
            bool[] expected = { false, false, false }; //{reached, infected, propagated};
            var result = controller.minimum(4,3,7,1);
            CollectionAssert.AreEqual(expected,result);

        }

        /*
		 * one passes only if the fault is reached, but does not infect. (R)
		 * This will be the case when condition c<= min pass and c=min;
		 * then the fault will be executed but because values are same it will not change the end result.
		 */

        [TestMethod]
        public void TestMethod2()
        {

            var controller = new Faulty_function_controller(0);
            bool[] expected = { true, false, false }; //{reached, infected, propagated};
            var result = controller.minimum(4, 3, 3, 1);
            CollectionAssert.AreEqual(expected, result);

        } 

        /*
		 * one passes only if the fault is reached, infects, but does not propagate. (RI^P)
		 * This will be true when the condition is executed: fault
		 * and c!= min : infection as minimum value is wrong
		 * however d is minimum of all. : no propagation.
		 * 
		 */

        [TestMethod]
        public void TestMethod3()
        {

            var controller = new Faulty_function_controller(0);
            bool[] expected = { true,true, false }; //{reached, infected, propagated};
            var result = controller.minimum(3,4,2, 1);
            CollectionAssert.AreEqual(expected, result);

        } 

        /*
		 * one passes only if the fault is reached, infects, and propagates � i.e., you detect a failure in the output.(RIPR)
		 * This will happen when 
		 * condition  executed : fault
		 * c < min : infection because of wrong minimum value
		 * and d<c but d> b : propagation
		 * the minimum value should be c but will be b
		*/

        [TestMethod]
        public void TestMethod4()
        {

            var controller = new Faulty_function_controller(0);
            bool[] expected = { true,true,true}; //{reached, infected, propagated};
            var result = controller.minimum(3,5,2,4);
            CollectionAssert.AreEqual(expected, result);

        }

        /*
		 * one passes only if the fault is not reached and the result is correct.(!R no other failure)
		 * This is again when condition is not reached 
		 * and minimum value is as expected
		 */

        [TestMethod]
        public void TestMethod5()
        {

            var controller = new Faulty_function_controller(0);
            bool[] expected = { false, false, false }; //{reached, infected, propagated};
            var result = controller.minimum(4, 3, 7, 1);
            CollectionAssert.AreEqual(expected, result);
            var result2 = controller.min_value();     
            Assert.AreEqual(1,result2);

        }
    }
}
