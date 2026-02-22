#include <bits/stdc++.h>
using namespace std;

int n; 
void bubblesort(int a[]){
    for (int i = 0 ; i < n - 1 ; i++){
        for (int j = 0 ; j < n - i - 1 ; j++){
            if (a[j] > a[j + 1]) swap(a[j] , a[j + 1]);
        }
    }
}

int main(){
    ios_base::sync_with_stdio(false);
    cin.tie(NULL);
    
    #ifndef ONLINE_JUDGE
    freopen("input.txt", "r",stdin);
    freopen("output.txt", "w",stdout);
    #endif

    cin >> n;
    int a[n];
    for (int i = 0 ; i < n ;i++){
        cin >> a[i];
    }
    bubblesort(a);
    for (int i : a) cout << i << " ";
}