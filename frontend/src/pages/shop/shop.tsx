import React from "react";
import DefaultLayout from "../../layouts/default-layout";

// -----------------------------------------------------------------------------------------
// #region Intefaces
// -----------------------------------------------------------------------------------------

interface ShopPageProps {}

// #endregion Intefaces

// -----------------------------------------------------------------------------------------
// #region Component
// -----------------------------------------------------------------------------------------

const ShopPage: React.FC<ShopPageProps> = (props: ShopPageProps) => {
    return (
        <DefaultLayout>
            <p>ShopPage</p>
        </DefaultLayout>
    );
};

// #endregion Component

// -----------------------------------------------------------------------------------------
// #region Exports
// -----------------------------------------------------------------------------------------

export default ShopPage;

// #endregion Exports
