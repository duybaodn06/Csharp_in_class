#include <bits/stdc++.h>
using namespace std;


int new_partition(int ar[], int low, int high) {
    int pivot = ar[high];
    int i = low - 1;
    for (int j = low ; j < high ; j++){
        if (ar[j] <= pivot ){
            i += 1;
            swap(ar[i], ar[j]);
        }
    }
    i ++;
    swap(ar[i], ar[high]);
    //i is pivot and in the middle
    return i;
}

void quick_sort(int ar[], int low, int high){
    if (low < high){
        int pi = new_partition(ar,low,high);
        quick_sort(ar, low, pi -1);
        quick_sort(ar, pi + 1, high);
    }
}

int main(){
    int ar[] = {9,7,5,11,12,2,14,3,10,6};
    quick_sort(ar, 0, (sizeof(ar) / sizeof(ar[0])) - 1);
    for (int x : ar){
        cout << x << " ";
    }
    return 0;
}