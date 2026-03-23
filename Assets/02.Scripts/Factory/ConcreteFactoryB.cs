using UnityEngine;
//Factory(추상클래스)를 상속받은 구체적인 공장 클래스
//실제로 ProductB(제품B)를 만들어서 반환하는 역할담당
public class ConcreteFactoryB : Factory
{
    [SerializeField] private ProductB m_ProductPrefab;

    public override IProduct GetProduct(Vector3 position)
    {
        GameObject instance = Instantiate(
            m_ProductPrefab.gameObject, 
            position, 
            Quaternion.identity);

        ProductB newProduct =  instance.GetComponent<ProductB>();
        newProduct.Initialize();

        instance.name = newProduct.ProductName;
        Debug.Log(GetLog(newProduct));

        return newProduct;
    }
}
