namespace Dll.util {

    public class Calculate{
        public static int ByteArrSum(byte[] arr){ //将字节数组中的所有元素 进行求和
            int sum = 0;
            for (int i = 0; i < arr.Length; i++) {
                sum = sum + arr[i];
            }
            return sum;
        }

        public static bool CompareArray(byte[] bt1, byte[] bt2){
            var len1 = bt1.Length;
            var len2 = bt2.Length;
            if (len1 != len2) {
                return false;
            }
            for (var i = 0; i < len1; i++) {
                if (bt1[i] != bt2[i])
                    return false;
            }
            return true;
        }

        //int size1 = sizeof(float); //4个字节
        //int hah = System.Runtime.InteropServices.Marshal.SizeOf(typeof(tSignalValueDef));
    }
}
