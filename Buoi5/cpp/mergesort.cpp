#include <bits/stdc++.h>
using namespace std;

void merge(int ar[], int l ,int mid, int r){
    int size1,size2;
    size1 = mid - l + 1; 
    size2 = r - mid;
    int lar[size1]; copy(ar + l, ar + mid + 1, lar);
    int rar[size2]; copy(ar + mid + 1, ar + r + 1, rar);
    
    int i,j; i = j = 0;
    int k = l;

    while (i < size1 && j < size2){
        if (lar[i] <= rar[j]){
            ar[k] = lar[i];
            i++;
        }
        else {
            ar[k] = rar[j];
            j++;
        }
        k++;
    }

    while (i < size1){
        ar[k] = lar[i];
        i++;
        k++;
    }
    while (j < size2){
        ar[k] = rar[j];
        j++;
        k++;
    }
}



void mergesort(int ar[],int l, int r){
    if (l < r){
        //split into 2
        int mid = (l + r) /2;

        //recursion like dfs
        mergesort(ar,l , mid);
        mergesort(ar,mid + 1, r);

        //after recursion
        merge(ar, l , mid , r);
    }
    

}


int main(){
    int ar[] = {2,8,5,3,9,4,1,7};
    mergesort(ar,0,(sizeof(ar) / sizeof(ar[0])) - 1);
    for (int t : ar) cout << t << " ";
}