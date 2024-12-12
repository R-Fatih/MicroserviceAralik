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
            }
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
            new ApiScope("OrderFullPermission","Full access to order resource")
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
                AllowedScopes={"CatalogReadPermission","DiscountReadPermission"}
            },
            //AdminClient
            new Client
            {
                ClientId="AdminId",
                ClientName="Admin Client",
                AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                ClientSecrets={ new Secret("AdminSecret".Sha256())},
                AllowedScopes={"CatalogFullPermission","DiscountFullPermission","OrderFullPermission",IdentityServerConstants.StandardScopes.Email,IdentityServerConstants.StandardScopes.OpenId,IdentityServerConstants.StandardScopes.Profile },
                AccessTokenLifetime=7200
            }
        };


    }
}