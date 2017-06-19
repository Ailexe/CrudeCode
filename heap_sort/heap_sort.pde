int num[] = {19, 25, 31, 5, 13, 7, 18, 29, 33, 2};
void setup() {
  heapSort(num);
  for (int i = 0; i < num.length; i++) {
    println(num[i]);
  }
}

void heapSort(int[] array){
  //ヒープ構造に並び替える
  for (int i = (array.length - 1) / 2; i >= 0; i--) {
    downheap(i, array.length - 1, array);
  }
  
  //降順にソートする
  for (int i = array.length - 1; i > 0; i--) {
    //ヒープの一番深い値と根を入れ替え値を確定する
    swap(0, i, array);
    //根についてヒープの並び替えをやり直す
    downheap(0, i - 1, array);
  }
}

//ヒープ構造にする
void downheap(int k, int r, int[] array) {
  int j;
  int temp = array[k];
  while (true) {
    j = 2 * k + 1;
    //注目子が配列から溢れたらループを抜ける
    if (j > r) break;

    if (j != r) {
      //左右の子のうち大きい方に注目する
      if (array[j + 1] > array[j]) {
        j = j + 1;
      }
    }

    //親が子より大きければ変更をせずにループを抜ける
    if (temp >= array[j]) break;

    //親に子の値を入れる
    array[k] = array[j];
    k = j;
  }
  //子に親の値を入れる
  array[k] = temp;
}

// 要素の交換
void swap(int i, int j, int[] array) {
  int temp = array[i];
  array[i] = array[j];
  array[j] = temp;
}
