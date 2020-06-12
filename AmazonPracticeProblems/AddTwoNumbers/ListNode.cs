namespace AddTwoNumbers
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }

        public static ListNode Insert(ListNode root, int value)
        {
            ListNode temp = new ListNode();
            ListNode ptr;
            temp.val = value;
            temp.next = null;

            if (root == null) 
                root = temp;
            else
            {
                ptr = root;
                
                while (ptr.next != null)
                    ptr = ptr.next;

                ptr.next = temp;
            }

            return root;
        }

        public static int GetNumFromListNode(ListNode ln)
        {

            ListNode currentNode = ln;

            int tensPlace = 1;
            int num = 0;

            while (currentNode != null)
            {
                currentNode.val *= tensPlace;
                num += currentNode.val;
                tensPlace *= 10;
                currentNode = currentNode.next;
            }

            return num;
        }

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {

            int num1 = ListNode.GetNumFromListNode(l1);
            int num2 = ListNode.GetNumFromListNode(l2);

            int numResult = num1 + num2;

            ListNode listNodeResult = GetListNodeFromNum(numResult);

            return listNodeResult;
        }

        public static ListNode GetListNodeFromNum(int num)
        {
            int[] numArr = GetNumArrayFromInt(num);

            int numArrLen = numArr.Length;

            ListNode root = new ListNode(numArr[numArrLen - 1]);

            for (int i = numArrLen - 2; i >= 0; i--)
            {
                ListNode.Insert(root, numArr[i]);
            }

            return root;
        }

        private static int[] GetNumArrayFromInt(int num)
        {
            if (num == 0)
                return new int[1];

            int _num = num;

            int numDigitsInNum = 0;

            while (_num > 0)
            {
                _num /= 10;
                numDigitsInNum++;
            }

            int[] digitsArr = new int[numDigitsInNum];

            for (int i = numDigitsInNum - 1; i >= 0; i--)
            {
                digitsArr[i] = num % 10;
                num = (num - (num % 10)) / 10;
            }

            return digitsArr;
        }
    }
}
