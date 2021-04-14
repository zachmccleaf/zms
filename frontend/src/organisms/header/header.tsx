import React from "react";
import Logo from "../../atoms/logo/logo";
import HeaderLink from "../../molecules/header-link/header-link";

// -----------------------------------------------------------------------------------------
// #region Interfaces
// -----------------------------------------------------------------------------------------

interface HeaderProps {}

// #endregion Interfaces

// -----------------------------------------------------------------------------------------
// #region Component
// -----------------------------------------------------------------------------------------

const Header: React.FC<HeaderProps> = (
    props: HeaderProps
) => {
    return (
        <div className='o-header'>
            <Logo/>
            <nav>
                <HeaderLink page='home' />
                <HeaderLink page='about' />
                <HeaderLink page='shop' />
            </nav>
        </div>
    );
};

// #endregion Component

// -----------------------------------------------------------------------------------------
// #region Export
// -----------------------------------------------------------------------------------------

export default Header;

// #endregion Export
