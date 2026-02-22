#include <bits/stdc++.h>
using namespace std;

void heapify(int ar[], int n, int i) {
    int l = 2 * i + 1;
    int r = 2 * i + 2;
    int largest = i;
    if (l < n && ar[l] > ar[largest]){
        largest = l;
    }
    if (r < n && ar[r] > ar[largest]){
        largest = r;
    }

    if (largest != i) {
        swap(ar[largest], ar[i]);
        heapify(ar, n, largest);
    }
}

void heap_sort(int ar[], int n){
    for (int i = n / 2 - 1 ; i >= 0 ; i--){
        heapify(ar, n, i);
    }
    for (int i = n - 1 ; i > 0 ; i--){
        swap(ar[i], ar[0]);
        heapify(ar, i, 0);
    }
}

int main(){
    int ar[] = {5,2,1,6,7,9,8,3,4,10};
    heap_sort(ar, 10);
    for (int i : ar){
        cout << i << " ";
    }
}