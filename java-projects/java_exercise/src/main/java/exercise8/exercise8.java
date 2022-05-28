package exercise8;


public class exercise8 {


    public static boolean isPrimeNumber(final int number) {
        
        boolean ret = true;
        
        if (number <= 1)
            ret = false;
               
        if (number % 2 == 0 && number > 2)
            ret = false;
        
        for(int i = 3;i<=Math.sqrt(number);i += 2){
            if(number % i == 0)
                ret = false;
        }
        return ret;
    }

    public static int calculateSumOfDigits(int number) {
       int length = (int) (Math.log10(number) + 1);
       int digits[];
       int sum = 0;
       digits = new int[length];
       for (int i = 0;i< length;i++){
           digits[i] = number % 10;
           number = number / 10;
           sum = sum + digits[i];
       }
      return sum;
    }

    public static int[] getPrimeNumbersFromInterval(int a, int b) {
        int primeNumbers[];
        int j =0;
        int length = 0;
            for(int i = a;i <= b; i++){
                if(isPrimeNumber(i) == true){
                    length++;
                } 
            }
        primeNumbers = new int[length];
        for(int i = a;i <= b; i++){
            if(isPrimeNumber(i) == true)
            {primeNumbers[j] = i;
            j++;
            } 
        }
        return primeNumbers;
    }

    public static double calculateGeometricMean(int[] primeNumbers) {
        double geometricalMean;
        long produs = 1;
        int length = primeNumbers.length;
        for(int i = 0;i < length;i++){
                produs = produs * primeNumbers[i];
        }
        geometricalMean = Math.pow(produs, 1.0 / length);
        return geometricalMean;
    }

    public static int numberOfPNWithEvenSumOfDigits(int[] primeNumbers) {
        int numberOfPN = 0;
        for(int i = 0;i < primeNumbers.length;i++){
            if(calculateSumOfDigits(primeNumbers[i]) % 2 == 0){
            numberOfPN++;
            } 
        }
        return numberOfPN;
    }

    public static void main(String[] args) {
        int a = 0;
        int b = 50;
        System.out.println("The geometric mean is: " + calculateGeometricMean(getPrimeNumbersFromInterval(a, b)));
        System.out.println("The number of prime numbers which have the sum of digits an even number is: " + numberOfPNWithEvenSumOfDigits(getPrimeNumbersFromInterval(a, b)));
    
    }
 
}