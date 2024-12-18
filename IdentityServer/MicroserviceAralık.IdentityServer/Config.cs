// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System.Collections.Generic;
using IdentityServer4;
using IdentityServer4.Models;

namespace MicroserviceAralık.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("ResourceCatalog")
            {
                Scopes = { "CatalogReadPermission","CatalogFullPermission" }
            },
            new ApiResource("ResourceDiscount")
            {
            Scopes={"DiscountReadPermission","DiscountFullPermission"}
            },
            new ApiResource("ResourceOrder")
            {
                Scopes={"OrderReadPermission","OrderFullPermission"}
            },
            new ApiResource("ResourceCargo")
            {

                Scopes={"CargoReadPermission","CargoFullPermission"}
            },
            new ApiResource("ResourceBasket")
            {
                Scopes={"BasketReadPermission","BasketFullPermission"}
            },
            new ApiResource("ResourceOcelot")
            {
                Scopes={"OcelotFullPermission"}
            },
            new ApiResource("ResourceImage")
            {
                Scopes={"ImageFullPermission","ImageReadPermission"}
            },
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)

        };


        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email(),
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            new ApiScope("CatalogReadPermission","Read access to catalog resource"),
            new ApiScope("CatalogFullPermission","Full access to catalog resource"),
            new ApiScope("DiscountReadPermission","Read access to discount resource"),
            new ApiScope("DiscountFullPermission","Full access to discount resource"),
            new ApiScope("OrderReadPermission","Read access to order resource"),
            new ApiScope("OrderFullPermission","Full access to order resource"),
            new ApiScope("CargoReadPermission","Read access to cargo resource"),
            new ApiScope("CargoFullPermission","Full acess to cargo resource"),
            new ApiScope("BasketReadPermssion","Read access to basket resource"),
            new ApiScope("BasketFullPermission","Full access to basket resource"),
            new ApiScope("OcelotFullPermission","Full access to oceolot resource"),
            new ApiScope("ImageFullPermission","Full access to image resource"),
            new ApiScope("ImageReadPermission","Read access to image resource"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };
        public static IEnumerable<Client> Clients => new Client[]
        {
            //visitorClient
            new Client
            {
                ClientId="VisitorId",
                ClientName="Visitor Client",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets={new Secret("VisitorSecret".Sha256())},
                AllowedScopes={"CatalogReadPermission","DiscountReadPermission","OcelotFullPermission","ImageReadPermission"}
            },
            //AdminClient
            new Client
            {
                ClientId="AdminId",
                ClientName="Admin Client",
                AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                ClientSecrets={ new Secret("AdminSecret".Sha256())},
                AllowedScopes={"CatalogFullPermission","DiscountFullPermission","OrderFullPermission","CargoFullPermission","BasketFullPermission", "OcelotFullPermission","ImageFullPermission",IdentityServerConstants.StandardScopes.Email,IdentityServerConstants.StandardScopes.OpenId,IdentityServerConstants.StandardScopes.Profile,IdentityServerConstants.LocalApi.ScopeName },
                AccessTokenLifetime=7200
            }
        };


    }
}