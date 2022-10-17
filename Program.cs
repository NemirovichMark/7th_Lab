using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Markup;

namespace _7th_Lab
{
    [System.Runtime.InteropServices.Guid("3D24E224-3864-4E04-BD90-77C1814654BD")]
    class Program
    {
        static void Main(string[] args)
        {
            /* Difference from the structures
             * When we using the structures, we operate with links to each memory allocation. 
             * When we send a structure as a method parameter we create a copy and method works with a copy (except ref modification).
             * If we send a class, we send a link to it's allocation. Sending the element of the class as like a always ref - sending. 
             * So, structure - the value (with under-values). Class - the reference to the aggregate of values (have additional parameters in the memory).
             * 
             */
            /* Inheritance
             * One class can be inherited from another one and get all fields, properties and methods of base class.
             * Any protected or public method can be modifyed with override operator (only for virtual base methods - that can be changed).
             * Any protected or public method can be rewritten with new operator. 
             * It allows to change behaviour of differnt children with common properties. 
             * 
             */
            
            /* Upcast
             * Child class can be upcasted to base class for ENCAPSULATING the fields, properties and methods of this class. 
             * For users will be shown only that fields and others.
             * that avaliable from base class but with modification of child class! 
             * And references to child fields, properties and methods from that (base) methods) too.
             * 
             */
        }
    }
}
