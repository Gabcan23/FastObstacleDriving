// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("7Y1XQf2YDXUrGlS5Tcirz02Oq3HTeA+87uOTzW7+xyodU2IaU3HHzkNER/ta0Jidgp5hVC4EZDOT/kN0M4ECITMOBQophUuF9A4CAgIGAwDTP+epeIyTU3F+EdvM+890iu+I2VLG0wca7xykmqKiXVpG4p2ZP878jZwyB5xEiB4E1cb0NsLK4y5eec3v3uL94y5M6gHCaQJ8hvvLZVJsvYECDAMzgQIJAYECAgO4PLxkz9C6i4wS07f//gtAJ6nQRen9YZKM/Ok/8oLiGBi/poYnoWchYhl28wmskf1v0SB8hZxIis+tkFal7lliwvqEdt0glZ9QdLUcxB63aY9rmjQmM2rtt/aVS7b/XMlM0TPLhB5BSvFPFYTavkMaU0U6JAEAAgMC");
        private static int[] order = new int[] { 9,7,2,9,4,9,10,8,8,10,11,12,12,13,14 };
        private static int key = 3;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
