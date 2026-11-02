# One-Pass Removal of k-th Node from End

https://www.hackerrank.com/contests/software-engineer-prep-kit/challenges/one-pass-removal-kth-from-end/problem?isFullScreen=true


Given the head of a singly linked list and an integer k, remove the k-th node from the end in one traversal and return the new head. 
If k is invalid, return the original list.

## Example

Input:
head = [5, 6, 7, 8]
k = 3

Output:
[6, 7, 8]

Explanation:

The list has 4 nodes. 
The k-th node from the end with k=3 is the 4th node from the end (value 5), which is the head. Removing it yields [6,7,8].
Input Format

The first line contains an integer n denoting the length of linked list.
The next n lines contains elements of the linked list.
The last line contains k.

## Example

4
5
6
7
8
3

here 4 is the length of the linked list, followed by the elements of the list and value of k.

Constraints:

0 <= number of nodes in head <= 1000
-10^9 <= value of each node <= 10^9
0 <= k <= 10^9

Output Format:

Return the head of the modified linked list after removal.

Sample Input 0:
1
5
1

Sample Output 0:
5

Sample Input 1:
2
1 
2
0

Sample Output 1:
1