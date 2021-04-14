import React from "react";
import Header from "../organisms/header/header";

// -----------------------------------------------------------------------------------------
// #region Intefaces
// -----------------------------------------------------------------------------------------

interface DefaultLayoutProps {
    children?: any;
}

// #endregion Intefaces

// -----------------------------------------------------------------------------------------
// #region Component
// -----------------------------------------------------------------------------------------

const DefaultLayout: React.FC<DefaultLayoutProps> = (props: DefaultLayoutProps) => {
    return (
        <div className="o-grid__container">
            <Header/>
            {props.children}
        </div>
    );
};

// #endregion Component

// -----------------------------------------------------------------------------------------
// #region Exports
// -----------------------------------------------------------------------------------------

export default DefaultLayout;

// #endregion Exports
