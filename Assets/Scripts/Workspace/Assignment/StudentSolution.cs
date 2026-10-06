using System;
using System.Collections.Generic;

namespace Assignment
{
    public class StudentSolution
    {
        #region Lecture

        public int LCT01_RecursiveFactorial(int n)
        {
            return Factorial(n);
        }

        private int Factorial(int n)
        {
            // base case
            if (n <= 1) return 1;

            // recursive case
            return n * Factorial(n - 1);
        }

        public int LCT02_RecursiveFibonacci(int n)
        {
            return Fibonacci(n);
        }

        private int Fibonacci(int n)
        {
            // base case
            if (n <= 0) return 0;
            if (n == 1) return 1;

            // recursive case
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        public int LCT03_RecursiveSumOfOneToN(int n)
        {
            return SumOfOneToN(n);
        }

        private int SumOfOneToN(int n)
        {
            // base case
            if (n <= 0) return 0;

            // recursive case
            return n + SumOfOneToN(n - 1);
        }

        public int LCT04_RecursiveSumOfNumbers(int[] numbers)
        {
            if (numbers == null) return 0;
            return SumOfNumbers(numbers, 0);
        }

        private int SumOfNumbers(int[] numbers, int index)
        {
            // base case: เมื่อวนลูปจนพ้นความยาวของ Array
            if (index >= numbers.Length) return 0;

            // recursive case
            return numbers[index] + SumOfNumbers(numbers, index + 1);
        }

        #endregion

        #region Assignment

        public int ASN01_RecursivePower(int baseNum, int exponent)
        {
            return Power(baseNum, exponent);
        }

        private int Power(int baseNum, int exponent)
        {
            // base case: ยกกำลัง 0 ได้ 1
            if (exponent <= 0) return 1;

            // recursive case: baseNum * baseNum^(exponent - 1)
            return baseNum * Power(baseNum, exponent - 1);
        }

        public bool ASN02_IsPalindrome(string str)
        {
            if (string.IsNullOrEmpty(str)) return true;
            return IsPalindrome(str, 0, str.Length - 1);
        }

        private bool IsPalindrome(string str, int start, int end)
        {
            // base case: หากตรวจสอบชนกันตรงกลางหรือเลื่อมกันแล้ว แสดงว่าเป็น Palindrome
            if (start >= end) return true;

            // หากอักขระหัว-ท้ายไม่ตรงกัน ไม่เป็น Palindrome
            if (str[start] != str[end]) return false;

            // recursive case: ขยับตัวชี้เข้าหากัน
            return IsPalindrome(str, start + 1, end - 1);
        }

        public int ASN03_RecursiveGCD(int a, int b)
        {
            return GCD(a, b);
        }

        private int GCD(int a, int b)
        {
            // base case: ตาม Euclidean Algorithm เมื่อ b เป็น 0 ห.ร.ม. คือ a
            if (b == 0) return a;

            // recursive case
            return GCD(b, a % b);
        }

        public int ASN04_RecursiveBinarySearch(int[] arr, int target)
        {
            if (arr == null || arr.Length == 0) return -1;
            return BinarySearch(arr, target, 0, arr.Length - 1);
        }

        private int BinarySearch(int[] arr, int target, int low, int high)
        {
            // base case: ค้นหาครบทุกช่องแล้วแต่ไม่พบ target
            if (low > high) return -1;

            int mid = low + (high - low) / 2;

            if (arr[mid] == target)
            {
                return mid;
            }
            else if (arr[mid] > target)
            {
                // recursive case: ค้นหาในฝั่งซ้าย
                return BinarySearch(arr, target, low, mid - 1);
            }
            else
            {
                // recursive case: ค้นหาในฝั่งขวา
                return BinarySearch(arr, target, mid + 1, high);
            }
        }

        #endregion
    }
}